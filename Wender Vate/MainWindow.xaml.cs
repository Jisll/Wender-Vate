using MaterialDesignThemes.Wpf;
using MySqlConnector;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CheckRam();
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void CheckRam()
        {
            ulong ramSize = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
            ulong minRamSize = 12UL * 1024UL * 1024UL * 1024UL;

            if (ramSize < minRamSize)
            {
                MessageBox.Show("Your computer has less than 12 GB of RAM and therefore does not meet the system requirements.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            else
            {
                // Nothing
            }
        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            string currentUser = Environment.UserName;
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string engineIniPath = $@"{appDataPath}\Hogwarts Legacy\Saved\Config\WindowsNoEditor\Engine.ini";

            try
            {
                string textToWrite =
@"[Core.System]
Paths=../../../Engine/Content
Paths=%GAMEDIR%Content
Paths=../../../Engine/Plugins/Media/BinkMedia/Content
Paths=../../../Phoenix/Plugins/Utilities/Content
Paths=../../../Phoenix/Plugins/Wwise/Content
Paths=../../../Engine/Plugins/Editor/GeometryMode/Content
Paths=../../../Phoenix/Plugins/MasterTickThrottler/Content
Paths=../../../Phoenix/Plugins/AnimationArchitect/Content
Paths=../../../Phoenix/Plugins/CustomizableCharacter/Content
Paths=../../../Engine/Plugins/FX/Niagara/Content
Paths=../../../Engine/Plugins/Experimental/PythonScriptPlugin/Content
Paths=../../../Phoenix/Plugins/MaterialPermuter/Content
Paths=../../../Phoenix/Plugins/AvaRenderTech/Content
Paths=../../../Engine/Plugins/WImgui/Content
Paths=../../../Phoenix/Plugins/AccessibilitySettings/Content
Paths=../../../Phoenix/Plugins/GameLogic/Content
Paths=../../../Engine/Plugins/Experimental/ControlRig/Content
Paths=../../../Phoenix/Plugins/CameraStack/Content
Paths=../../../Phoenix/Plugins/Odyssey/Content
Paths=../../../Phoenix/Plugins/StencilManager/Content
Paths=../../../Phoenix/Plugins/SkinFX/Content
Paths=../../../Phoenix/Plugins/Toolset/Content
Paths=../../../Phoenix/Plugins/FXUtil/Content
Paths=../../../Phoenix/Plugins/MultiFX2/Content
Paths=../../../Phoenix/Plugins/HoverDrone/Content
Paths=../../../Phoenix/Plugins/CachedLevelBounds/Content
Paths=../../../Phoenix/Plugins/LoadingScreen/Content
Paths=../../../Phoenix/Plugins/SceneRig/Content
Paths=../../../Phoenix/Plugins/Ambulatory/Content
Paths=../../../Phoenix/Plugins/Able/Content
Paths=../../../Phoenix/Plugins/Icarus/Content
Paths=../../../Phoenix/Plugins/Mercuna/Content
Paths=../../../Phoenix/Plugins/GlobalLightRig/Content
Paths=../../../Phoenix/Plugins/TickSequencer/Content
Paths=../../../Phoenix/Plugins/RenderSettings/Content
Paths=../../../Phoenix/Plugins/LightCulling/Content
Paths=../../../Phoenix/Plugins/EnvironmentalGlobals/Content
Paths=../../../Phoenix/Plugins/ConsoleMacros/Content
Paths=../../../Phoenix/Plugins/AnimatedLights/Content
Paths=../../../Phoenix/Plugins/LerpVolumes/Content
Paths=../../../Phoenix/Plugins/ActorMeshStates/Content
Paths=../../../Phoenix/Plugins/DayNight/Content
Paths=../../../Phoenix/Plugins/NiagaraStarField/Content
Paths=../../../Phoenix/Plugins/Weather/Content
Paths=../../../Phoenix/Plugins/Wind/Content
Paths=../../../Phoenix/Plugins/WBDynamicSplines/Content
Paths=../../../Phoenix/Plugins/GlobalLightGroups/Content
Paths=../../../Phoenix/Plugins/WorldFX/Content
Paths=../../../Engine/Plugins/Editor/PivotTool/Content
Paths=../../../Engine/Plugins/Experimental/GeometryProcessing/Content
Paths=../../../Engine/Plugins/FX/NiagaraExtras/Content
Paths=../../../Phoenix/Plugins/EditorUtilityAssetsPlugin/Content
Paths=../../../Phoenix/Plugins/PeevesPlugin/Content
Paths=../../../Phoenix/Plugins/ACLPlugin/Content
Paths=../../../Phoenix/Plugins/GameplayMods/Content
Paths=../../../Engine/Plugins/Hydra/Content
Paths=../../../Phoenix/Plugins/BTUtilityAI/Content
Paths=../../../Phoenix/Plugins/Flow/Content
Paths=../../../Phoenix/Plugins/Runtime/HoudiniEngine/Content
Paths=../../../Engine/Plugins/WBGM/Developer/BlueprintValidator/Content
Paths=../../../Engine/Plugins/MegascansPlugin/Content
Paths=../../../Phoenix/Plugins/UMGFocus/Content
Paths=../../../Phoenix/Plugins/PSOCaching/Content
Paths=../../../Engine/Plugins/VirtualProduction/RemoteControl/Content
Paths=../../../Engine/Plugins/Experimental/FieldSystemPlugin/Content
Paths=../../../Phoenix/Plugins/HoudiniNiagara/Content
Paths=../../../Engine/Plugins/Runtime/Nvidia/DLSS/Content
Paths=../../../Engine/Plugins/Experimental/ModelingToolsEditorMode/Content
Paths=../../../Engine/Plugins/Experimental/MeshModelingToolset/Content
Paths=../../../Engine/Plugins/Runtime/HairStrands/Content
Paths=../../../Engine/Plugins/Experimental/ChaosCaching/Content
Paths=../../../Phoenix/Plugins/IGCacheSim/Content
Paths=../../../Engine/Plugins/Watermark/Content
Paths=../../../Engine/Plugins/FX/CascadeToNiagaraConverter/Content
Paths=../../../Engine/Plugins/Importers/USDImporter/Content
Paths=../../../Engine/Plugins/Enterprise/MDLImporter/Content
Paths=../../../Engine/Plugins/MovieScene/SequencerScripting/Content
Paths=../../../Phoenix/Plugins/MasterOverlapThrottler/Content
Paths=../../../Engine/Plugins/Runtime/AMD/FSR/Content
Paths=../../../Engine/Plugins/Runtime/AMD/FSR2/Content
Paths=../../../Engine/Plugins/Runtime/Intel/XeSS/Content
Paths=../../../Engine/Plugins/MovieScene/MovieRenderPipeline/Content
Paths=../../../Engine/Plugins/Compositing/OpenColorIO/Content
Paths=../../../Engine/Plugins/MovieScene/MoviePipelineMaskRenderPass/Content
Paths=../../../Engine/Plugins/Enterprise/StaticMeshEditorExtension/Content
Paths=../../../Engine/Plugins/Editor/MeshEditor/Content
Paths=../../../Engine/Plugins/Experimental/GeometryCollectionPlugin/Content
Paths=../../../Engine/Plugins/Experimental/ChaosSolverPlugin/Content
Paths=../../../Engine/Plugins/Enterprise/DataprepEditor/Content
Paths=../../../Engine/Plugins/Enterprise/DatasmithContent/Content
Paths=../../../Engine/Plugins/Runtime/Nvidia/Streamline/Content
Paths=../../../Phoenix/Plugins/ChromaSDKPlugin/Content
Paths=../../../Phoenix/Plugins/ClothHelper/Content
Paths=../../../Phoenix/Plugins/DirectorCam/Content
Paths=../../../Phoenix/Plugins/GPUConfig/Content
Paths=../../../Phoenix/Plugins/HiveMind/HiveMind/Content
Paths=../../../Phoenix/Plugins/HiveMind/Platforms/Windows/HiveMindCryptoWindows/Content
Paths=../../../Phoenix/Plugins/IcarusTools/Content
Paths=../../../Phoenix/Plugins/ImpostorBaker/Content
Paths=../../../Phoenix/Plugins/InstaLODMeshReduction/Content
Paths=../../../Phoenix/Plugins/Mastermind/Content
Paths=../../../Phoenix/Plugins/RecordMovieInterface/Content
Paths=../../../Phoenix/Plugins/SimplifyRockGeneration/Content
Paths=../../../Phoenix/Plugins/StreamingComplexityTool/Content
Paths=../../../Phoenix/Plugins/UIDiagnostics/Content
Paths=../../../Phoenix/Plugins/WBPC/Content
Paths=../../../Phoenix/Plugins/WImguiAcknowledgementManager/Content
Paths=../../../Phoenix/Plugins/WImguiAvaLocDirect/Content
Paths=../../../Phoenix/Plugins/WImguiConjurationBudget/Content
Paths=../../../Phoenix/Plugins/WImguiFriendlyStats/Content
Paths=../../../Phoenix/Plugins/WorldEventPreviewer/Content
Paths=../../../Engine/Plugins/Developer/AnimationSharing/Content
Paths=../../../Engine/Plugins/Editor/SpeedTreeImporter/Content
Paths=../../../Engine/Plugins/Experimental/ChaosClothEditor/Content
Paths=../../../Engine/Plugins/Experimental/ChaosNiagara/Content
Paths=../../../Engine/Plugins/Experimental/MotoSynth/Content
Paths=../../../Engine/Plugins/Media/MediaCompositing/Content
Paths=../../../Engine/Plugins/Runtime/Synthesis/Content
Paths=../../../Engine/Plugins/Runtime/AudioSynesthesia/Content

[SystemSettings]
r.AllowOcclusionQueries=1
r.Shaders.Optimize=1
r.ShaderPipelineCache.StartupMode=3
r.ShaderPipelineCache.Enabled=1
r.ShaderPipelineCache.ReportPSO=0
r.ShaderPipelineCache.GameFileMaskEnabled=0
r.ShaderPipelineCache.LazyLoadShadersWhenPSOCacheIsPresent=1
r.ShaderPipelineCache.BatchSize=50
r.XGEShaderCompile=1
r.XGEShaderCompile.Mode=1
r.XGEShaderCompile.Xml.BatchGroupSize=256
r.XGEShaderCompile.Xml.BatchSize=16
r.XGEShaderCompile.Xml.JobTimeout=0.500000
r.GPUParticle.Simulate=1
r.GTSyncType=1
r.OneFrameThreadLag=1
r.Shadow.WholeSceneShadowCacheMb=512
gc.TimeBetweenPurgingPendingKillObjects=600
gc.NumRetriesBeforeForcingGC=4
gc.MinDesiredObjectsPerSubTask=20
s.ForceGCAfterLevelStreamedOut=0
s.ContinuouslyIncrementalGCWhileLevelsPendingPurge=0
r.ShaderPipelineCache.BatchTime=1
r.ShaderPipelineCache.BackgroundBatchTime=0
r.Streaming.Boost=1
r.Streaming.LimitPoolSizeToVRAM=0
r.Streaming.UseMaterialData=1
r.Streaming.UseNewMetrics=1
r.Streaming.UsePerTextureBias=1
r.Shaders.FastMath=1
r.Streaming.DefragDynamicBounds=1
r.Streaming.PoolSize=6092
r.Streaming.MaxTempMemoryAllowed=512
r.FastVRam.Tonemap=1
r.FastVRam.Upscale=1
r.FastVRam.VelocityFlat=1
r.FastVRam.VelocityMax=1
r.FastVRam.VolumetricFog=1
r.FastVRam.MotionBlur=1
r.FastVRam.SceneColor=1
r.FastVRam.SceneDepth=1
r.FastVRam.ScreenSpaceShadowMask=1
r.FastVRam.HZB=1
r.FastVRam.Histogram=1
r.FastVRam.HistogramReduce=1
r.FastVRam.LPV=1
r.FastVRam.DistanceFieldNormal=1
r.FastVRam.DistanceFieldShadows=1
r.FastVRam.DistanceFieldTileIntersectionResources=1
r.FastVRam.DistortHistory=1
r.FastVRam.Distortion=1
r.FastVRam.Downsample=1
r.FastVRam.EyeAdaptation=1
r.FastVRam.ForwardLightingCullingResources=1
r.FastVRam.DistanceFieldAODownsampledBentNormal=1
r.FastVRam.DistanceFieldAOHistory=1
r.FastVRam.DistanceFieldAOScreenGridResources=1
r.FastVRam.DistanceFieldCulledObjectBuffers=1
r.FastVRam.DOFPostfilter=1
r.FastVRam.DOFReduce=1
r.FastVRam.DOFSetup=1
r.FastVRam.CombineLUTs=1
r.FastVRam.BokehDOF=1
r.FastVRam.ShadowCSM=1
r.FastVRam.ShadowPerObject=1
r.FastVRam.PostProcessMaterial=1
r.Streaming.MinMipForSplitRequest=0
r.Streaming.HiddenPrimitiveScale=0.25
r.Streaming.AmortizeCPUToGPUCopy=1
r.Streaming.MaxNumTexturesToStreamPerFrame=2
r.Streaming.NumStaticComponentsProcessedPerFrame=2
r.Streaming.FramesForFullUpdate=1
s.AsyncLoadingThreadEnabled=1
s.AsyncLoadingTimeLimit=2
s.LevelStreamingActorsUpdateTimeLimit=2
s.UnregisterComponentsTimeLimit=2
s.AsyncLoadingUseFullTimeLimit=0
s.IoDispatcherCacheSizeMB=256
s.LevelStreamingComponentsRegistrationGranularity=1
s.LevelStreamingComponentsUnregistrationGranularity=1
s.MaxIncomingRequestsToStall=1
s.MaxReadyRequestsToStallMB=0
s.MinBulkDataSizeForAsyncLoading=0
s.PriorityAsyncLoadingExtraTime=0
s.PriorityLevelStreamingActorsUpdateExtraTime=0
r.SkeletalMeshLODBias=1
r.StaticMeshLODDistanceScale=0.5
r.ParticleLODBias=1
r.DefaultFeature.Bloom=0
r.DefaultFeature.LensFlare=0
r.DefaultFeature.AmbientOcclusion=0
r.DefaultFeature.AmbientOcclusionStaticFraction=0
r.DefaultFeature.MotionBlur=0
r.DefaultFeature.AntiAliasing=0
r.DefaultFeature.AntiAliasing=0
r.DefaultFeature.Shadow=0
r.DefaultFeature.Refraction=0
r.DefaultFeature.Lighting=0
r.DefaultFeature.Fog=0
r.ViewDistanceScale=0.8
r.DetailMode=0
r.Tonemapper.GrainQuantization=0
r.Tonemapper.Quality=0
r.EmitterSpawnRateScale=0.5
r.EmitterTimeScale=0.5
r.ParticleLightQuality=0
r.LightFunctionQuality=0
r.TranslucencyLightingVolumeDim=16
r.TranslucencyVolumeBlur=0
r.LensFlareQuality=0
r.SceneColorFormat=3
r.SceneColorFringeQuality=0
r.DistanceFieldAO=0
r.DistanceFieldGI=0
r.ScreenPercentage=75
r.DefaultFeature.MotionBlurQuality=0
r.DefaultFeature.AmbientOcclusionLevels=0
r.DefaultFeature.AmbientOcclusionRadiusScale=0
r.ShadingPath=2

[ConsoleVariables]
AllowAsyncRenderThreadUpdates=1
AllowAsyncRenderThreadUpdatesDuringGamethreadUpdates=1
AllowAsyncRenderThreadUpdatesEditor=1";


                progressBar.Visibility = Visibility.Visible;


                using (StreamWriter writer = new StreamWriter(engineIniPath))
                {
                    await writer.WriteAsync(textToWrite);
                }

                MessageBox.Show("Installed Wender Vate to Hogwarts Legacy");

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void DialogHost_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void about_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Hey, I was programmed in C# and the programmer is Jisll!" + 
                " \nI'm just helping you to fix Hogwarts Legacy because the stuttering and more is annoying, isn't it? ", "Wender Vate");

            e.Handled = true;
        }

        private async void uninstall_Click(object sender, RoutedEventArgs e)
        {
            string currentUser = Environment.UserName;
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string engineIniPath = $@"{appDataPath}\Hogwarts Legacy\Saved\Config\WindowsNoEditor\Engine.ini";

            try
            {
                string textToWrite =
@"[Core.System]
Paths=../../../Engine/Content
Paths=%GAMEDIR%Content
Paths=../../../Engine/Plugins/Media/BinkMedia/Content
Paths=../../../Phoenix/Plugins/Utilities/Content
Paths=../../../Phoenix/Plugins/Wwise/Content
Paths=../../../Engine/Plugins/Editor/GeometryMode/Content
Paths=../../../Phoenix/Plugins/MasterTickThrottler/Content
Paths=../../../Phoenix/Plugins/AnimationArchitect/Content
Paths=../../../Phoenix/Plugins/CustomizableCharacter/Content
Paths=../../../Engine/Plugins/FX/Niagara/Content
Paths=../../../Engine/Plugins/Experimental/PythonScriptPlugin/Content
Paths=../../../Phoenix/Plugins/MaterialPermuter/Content
Paths=../../../Phoenix/Plugins/AvaRenderTech/Content
Paths=../../../Engine/Plugins/WImgui/Content
Paths=../../../Phoenix/Plugins/AccessibilitySettings/Content
Paths=../../../Phoenix/Plugins/GameLogic/Content
Paths=../../../Engine/Plugins/Experimental/ControlRig/Content
Paths=../../../Phoenix/Plugins/CameraStack/Content
Paths=../../../Phoenix/Plugins/Odyssey/Content
Paths=../../../Phoenix/Plugins/StencilManager/Content
Paths=../../../Phoenix/Plugins/SkinFX/Content
Paths=../../../Phoenix/Plugins/Toolset/Content
Paths=../../../Phoenix/Plugins/FXUtil/Content
Paths=../../../Phoenix/Plugins/MultiFX2/Content
Paths=../../../Phoenix/Plugins/HoverDrone/Content
Paths=../../../Phoenix/Plugins/CachedLevelBounds/Content
Paths=../../../Phoenix/Plugins/LoadingScreen/Content
Paths=../../../Phoenix/Plugins/SceneRig/Content
Paths=../../../Phoenix/Plugins/Ambulatory/Content
Paths=../../../Phoenix/Plugins/Able/Content
Paths=../../../Phoenix/Plugins/Icarus/Content
Paths=../../../Phoenix/Plugins/Mercuna/Content
Paths=../../../Phoenix/Plugins/GlobalLightRig/Content
Paths=../../../Phoenix/Plugins/TickSequencer/Content
Paths=../../../Phoenix/Plugins/RenderSettings/Content
Paths=../../../Phoenix/Plugins/LightCulling/Content
Paths=../../../Phoenix/Plugins/EnvironmentalGlobals/Content
Paths=../../../Phoenix/Plugins/ConsoleMacros/Content
Paths=../../../Phoenix/Plugins/AnimatedLights/Content
Paths=../../../Phoenix/Plugins/LerpVolumes/Content
Paths=../../../Phoenix/Plugins/ActorMeshStates/Content
Paths=../../../Phoenix/Plugins/DayNight/Content
Paths=../../../Phoenix/Plugins/NiagaraStarField/Content
Paths=../../../Phoenix/Plugins/Weather/Content
Paths=../../../Phoenix/Plugins/Wind/Content
Paths=../../../Phoenix/Plugins/WBDynamicSplines/Content
Paths=../../../Phoenix/Plugins/GlobalLightGroups/Content
Paths=../../../Phoenix/Plugins/WorldFX/Content
Paths=../../../Engine/Plugins/Editor/PivotTool/Content
Paths=../../../Engine/Plugins/Experimental/GeometryProcessing/Content
Paths=../../../Engine/Plugins/FX/NiagaraExtras/Content
Paths=../../../Phoenix/Plugins/EditorUtilityAssetsPlugin/Content
Paths=../../../Phoenix/Plugins/PeevesPlugin/Content
Paths=../../../Phoenix/Plugins/ACLPlugin/Content
Paths=../../../Phoenix/Plugins/GameplayMods/Content
Paths=../../../Engine/Plugins/Hydra/Content
Paths=../../../Phoenix/Plugins/BTUtilityAI/Content
Paths=../../../Phoenix/Plugins/Flow/Content
Paths=../../../Phoenix/Plugins/Runtime/HoudiniEngine/Content
Paths=../../../Engine/Plugins/WBGM/Developer/BlueprintValidator/Content
Paths=../../../Engine/Plugins/MegascansPlugin/Content
Paths=../../../Phoenix/Plugins/UMGFocus/Content
Paths=../../../Phoenix/Plugins/PSOCaching/Content
Paths=../../../Engine/Plugins/VirtualProduction/RemoteControl/Content
Paths=../../../Engine/Plugins/Experimental/FieldSystemPlugin/Content
Paths=../../../Phoenix/Plugins/HoudiniNiagara/Content
Paths=../../../Engine/Plugins/Runtime/Nvidia/DLSS/Content
Paths=../../../Engine/Plugins/Experimental/ModelingToolsEditorMode/Content
Paths=../../../Engine/Plugins/Experimental/MeshModelingToolset/Content
Paths=../../../Engine/Plugins/Runtime/HairStrands/Content
Paths=../../../Engine/Plugins/Experimental/ChaosCaching/Content
Paths=../../../Phoenix/Plugins/IGCacheSim/Content
Paths=../../../Engine/Plugins/Watermark/Content
Paths=../../../Engine/Plugins/FX/CascadeToNiagaraConverter/Content
Paths=../../../Engine/Plugins/Importers/USDImporter/Content
Paths=../../../Engine/Plugins/Enterprise/MDLImporter/Content
Paths=../../../Engine/Plugins/MovieScene/SequencerScripting/Content
Paths=../../../Phoenix/Plugins/MasterOverlapThrottler/Content
Paths=../../../Engine/Plugins/Runtime/AMD/FSR/Content
Paths=../../../Engine/Plugins/Runtime/AMD/FSR2/Content
Paths=../../../Engine/Plugins/Runtime/Intel/XeSS/Content
Paths=../../../Engine/Plugins/MovieScene/MovieRenderPipeline/Content
Paths=../../../Engine/Plugins/Compositing/OpenColorIO/Content
Paths=../../../Engine/Plugins/MovieScene/MoviePipelineMaskRenderPass/Content
Paths=../../../Engine/Plugins/Enterprise/StaticMeshEditorExtension/Content
Paths=../../../Engine/Plugins/Editor/MeshEditor/Content
Paths=../../../Engine/Plugins/Experimental/GeometryCollectionPlugin/Content
Paths=../../../Engine/Plugins/Experimental/ChaosSolverPlugin/Content
Paths=../../../Engine/Plugins/Enterprise/DataprepEditor/Content
Paths=../../../Engine/Plugins/Enterprise/DatasmithContent/Content
Paths=../../../Engine/Plugins/Runtime/Nvidia/Streamline/Content
Paths=../../../Phoenix/Plugins/ChromaSDKPlugin/Content
Paths=../../../Phoenix/Plugins/ClothHelper/Content
Paths=../../../Phoenix/Plugins/DirectorCam/Content
Paths=../../../Phoenix/Plugins/GPUConfig/Content
Paths=../../../Phoenix/Plugins/HiveMind/HiveMind/Content
Paths=../../../Phoenix/Plugins/HiveMind/Platforms/Windows/HiveMindCryptoWindows/Content
Paths=../../../Phoenix/Plugins/IcarusTools/Content
Paths=../../../Phoenix/Plugins/ImpostorBaker/Content
Paths=../../../Phoenix/Plugins/InstaLODMeshReduction/Content
Paths=../../../Phoenix/Plugins/Mastermind/Content
Paths=../../../Phoenix/Plugins/RecordMovieInterface/Content
Paths=../../../Phoenix/Plugins/SimplifyRockGeneration/Content
Paths=../../../Phoenix/Plugins/StreamingComplexityTool/Content
Paths=../../../Phoenix/Plugins/UIDiagnostics/Content
Paths=../../../Phoenix/Plugins/WBPC/Content
Paths=../../../Phoenix/Plugins/WImguiAcknowledgementManager/Content
Paths=../../../Phoenix/Plugins/WImguiAvaLocDirect/Content
Paths=../../../Phoenix/Plugins/WImguiConjurationBudget/Content
Paths=../../../Phoenix/Plugins/WImguiFriendlyStats/Content
Paths=../../../Phoenix/Plugins/WorldEventPreviewer/Content
Paths=../../../Engine/Plugins/Developer/AnimationSharing/Content
Paths=../../../Engine/Plugins/Editor/SpeedTreeImporter/Content
Paths=../../../Engine/Plugins/Experimental/ChaosClothEditor/Content
Paths=../../../Engine/Plugins/Experimental/ChaosNiagara/Content
Paths=../../../Engine/Plugins/Experimental/MotoSynth/Content
Paths=../../../Engine/Plugins/Media/MediaCompositing/Content
Paths=../../../Engine/Plugins/Runtime/Synthesis/Content
Paths=../../../Engine/Plugins/Runtime/AudioSynesthesia/Content";


                progressBar.Visibility = Visibility.Visible;


                using (StreamWriter writer = new StreamWriter(engineIniPath))
                {
                    await writer.WriteAsync(textToWrite);
                }

                MessageBox.Show("Uninstalled Wender Vate from Hogwarts Legacy");

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
