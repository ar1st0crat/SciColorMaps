using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Media.Audio;
using Windows.Media.Capture;
using Windows.Media.Devices;
using Windows.Media.MediaProperties;
using Windows.Media.Render;
using Windows.Media.Transcoding;
using Windows.Storage;
using Windows.UI.Popups;

namespace SciColorMaps.DemoUwp
{
    class AudioService
    {
        /// <summary>
        /// Audio graph and i/o nodes used for sound recording
        /// </summary>
        private AudioGraph _audioGraph;
        private AudioDeviceOutputNode _deviceOutputNode;
        private AudioDeviceInputNode _deviceInputNode;
        private AudioFileOutputNode _fileOutputNode;

        private const string TemporaryWaveFile = "scicolormaps_demo.wav";

        public async Task<Signal> LoadSignalAsync(StorageFile file)
        {
            Stream stream;

            // if user opens WAV-file then we load its contents directly
            if (file.Name.EndsWith("wav", StringComparison.OrdinalIgnoreCase))
            {
                stream = await file.OpenStreamForReadAsync();
            }
            // otherwise transcode to wave
            else
            {
                var transcoder = new MediaTranscoder();
                var profile = MediaEncodingProfile.CreateWav(AudioEncodingQuality.Medium);

                var temporaryFile = await ApplicationData.Current.TemporaryFolder.TryGetItemAsync(TemporaryWaveFile) as StorageFile;

                if (temporaryFile != null)
                {
                    await temporaryFile.DeleteAsync(StorageDeleteOption.Default);
                }

                temporaryFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync(TemporaryWaveFile);

                if (temporaryFile == null)
                {
                    return null;
                }

                var preparedTranscodeResult = await transcoder.PrepareFileTranscodeAsync(file, temporaryFile, profile);

                if (preparedTranscodeResult.CanTranscode)
                {
                    await preparedTranscodeResult.TranscodeAsync();
                }
                else
                {
                    await new MessageDialog("Error: could not convert to wave!").ShowAsync();
                }

                stream = await temporaryFile.OpenStreamForReadAsync();
            }

            var signal = new Signal();

            await Task.Run(() => signal.Load(stream));

            return signal;
        }

        public async Task<Signal> LoadRecordedSignalAsync()
        {
            var temporaryFile = await ApplicationData.Current.TemporaryFolder.GetFileAsync(TemporaryWaveFile);
            var stream = await temporaryFile.OpenStreamForReadAsync();
            var signal = new Signal();

            await Task.Run(() => signal.Load(stream));

            return signal;
        }

        /// <summary>
        /// Recording code is taken from UWP samples and slightly reduced
        /// 
        /// - see official UWP samples on GitHub
        ///   https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/AudioCreation/cs/AudioCreation/Scenario2_DeviceCapture.xaml.cs
        /// 
        /// </summary>
        public async Task StartRecording()
        {
            await CreateAudioGraph();

            var temporaryFile = await ApplicationData.Current.TemporaryFolder.TryGetItemAsync(TemporaryWaveFile) as StorageFile;

            if (temporaryFile != null)
            {
                await temporaryFile.DeleteAsync(StorageDeleteOption.Default);
            }

            temporaryFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync(TemporaryWaveFile);
            
            var fileProfile = MediaEncodingProfile.CreateWav(AudioEncodingQuality.Medium);

            var fileOutputNodeResult = await _audioGraph.CreateFileOutputNodeAsync(temporaryFile, fileProfile);

            if (fileOutputNodeResult.Status != AudioFileNodeCreationStatus.Success)
            {
                await new MessageDialog("Cannot create output file: " + fileOutputNodeResult.Status).ShowAsync();
                return;
            }

            _fileOutputNode = fileOutputNodeResult.FileOutputNode;

            // Connect the input node to both output nodes
            _deviceInputNode.AddOutgoingConnection(_fileOutputNode);
            _deviceInputNode.AddOutgoingConnection(_deviceOutputNode);

            // Ta da!
            _audioGraph.Start();
        }

        public async Task StopRecording()
        {
            if (_audioGraph == null)
            {
                return;
            }

            _audioGraph.Stop();

            var finalizeResult = await _fileOutputNode.FinalizeAsync();

            if (finalizeResult != TranscodeFailureReason.None)
            {
                await new MessageDialog("Finalization of file failed: " + finalizeResult).ShowAsync();
                // return;
            }

            _audioGraph.Dispose();
            _audioGraph = null;
        }

        private async Task CreateAudioGraph()
        {
            var outputDevices = await DeviceInformation.FindAllAsync(MediaDevice.GetAudioRenderSelector());

            var settings = new AudioGraphSettings(AudioRenderCategory.Media)
            {
                QuantumSizeSelectionMode = QuantumSizeSelectionMode.LowestLatency,
                PrimaryRenderDevice = outputDevices[0]
            };

            var result = await AudioGraph.CreateAsync(settings);

            if (result.Status != AudioGraphCreationStatus.Success)
            {
                await new MessageDialog("AudioGraph Creation Error: " + result.Status).ShowAsync();
                return;
            }

            _audioGraph = result.Graph;

            // Create a device output node
            var deviceOutputNodeResult = await _audioGraph.CreateDeviceOutputNodeAsync();

            if (deviceOutputNodeResult.Status != AudioDeviceNodeCreationStatus.Success)
            {
                await new MessageDialog("Audio Device Output unavailable: " + deviceOutputNodeResult.Status).ShowAsync();
                return;
            }

            _deviceOutputNode = deviceOutputNodeResult.DeviceOutputNode;

            // Create a device input node using the default audio input device
            var deviceInputNodeResult = await _audioGraph.CreateDeviceInputNodeAsync(MediaCategory.Other);

            if (deviceInputNodeResult.Status != AudioDeviceNodeCreationStatus.Success)
            {
                await new MessageDialog("Audio Device Input unavailable: " + deviceInputNodeResult.Status).ShowAsync();

                _audioGraph.Dispose();
                _audioGraph = null;

                return;
            }

            _deviceInputNode = deviceInputNodeResult.DeviceInputNode;

            // Because we are using lowest latency setting, 
            // in general, we need to handle device disconnection errors
            // graph.UnrecoverableErrorOccurred += Graph_UnrecoverableErrorOccurred;
        }
    }
}
