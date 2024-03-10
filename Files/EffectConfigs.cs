/// <summary>
/// IDs of all post processing effect configs that can be set via the VTube Studio API.
/// There are currently 258 configs.
/// 
/// This file was automatically generated on Sunday, 10 March 2024 03:05
/// </summary>
public enum EffectConfigs
{
	// --------- Effect: ColorGrading -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	ColorGrading_Strength,

	// type: Float, sets_active: False
	// min: -180, max: 180
	// default: 0
	// explanation: Hue shift
	ColorGrading_HueShift,

	// type: Float, sets_active: False
	// min: -100, max: 100
	// default: 0
	// explanation: Saturation
	ColorGrading_Saturation,

	// type: Float, sets_active: False
	// min: -100, max: 100
	// default: 0
	// explanation: Brightness
	ColorGrading_Brightness,

	// type: Float, sets_active: False
	// min: -100, max: 100
	// default: 0
	// explanation: Contrast
	ColorGrading_Contrast,

	// type: Color, sets_active: False
	// default: FFFFFF alpha: False
	// explanation: Color filter
	ColorGrading_ColorFilter,

	// type: Float, sets_active: False
	// min: -100, max: 100
	// default: 0
	// explanation: Whitebalance temperature
	ColorGrading_WhitebalanceTemperature,

	// type: Float, sets_active: False
	// min: -100, max: 100
	// default: 0
	// explanation: Whitebalance tint
	ColorGrading_WhitebalanceTint,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Invert color
	ColorGrading_Invert,



	// --------- Effect: WeatherEffects -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Rain strength
	WeatherEffects_RainStrength,

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Snow strength
	WeatherEffects_SnowStrength,

	// type: Bool, sets_active: False
	// default: True
	// explanation: Rain  -  In front
	WeatherEffects_RainInFront,

	// type: Bool, sets_active: False
	// default: True
	// explanation: Snow  -  In front
	WeatherEffects_SnowInFront,



	// --------- Effect: Bloom -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	Bloom_Strength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: Model color darken
	Bloom_ModelColorDarken,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Background color darken
	Bloom_BackgroundColorDarken,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.4
	// explanation: Bloom threshold
	Bloom_MainThreshold,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.3
	// explanation: Bloom intensity
	Bloom_MainIntensity,

	// type: Color, sets_active: False
	// default: 62159B alpha: False
	// explanation: Bloom tint color
	Bloom_MainColorTint,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.4
	// explanation: Light streak threshold
	Bloom_StreakThreshold,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.3
	// explanation: Light streak intensity
	Bloom_StreakIntensity,

	// type: Color, sets_active: False
	// default: 870B8F alpha: False
	// explanation: Light streak tint color
	Bloom_StreakColorTint,

	// type: Bool, sets_active: False
	// default: False
	// explanation: Light streak vertical
	Bloom_StreakVertical,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Microphone effect - Microphone volume boosts strength
	Bloom_MicIncreasesBloom,

	// type: Int, sets_active: False
	// min: 0, max: 10
	// default: 7
	// explanation: Quality - Bloom quality
	Bloom_Quality,



	// --------- Effect: Backlight -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	Backlight_Strength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.4
	// explanation: Blur BG overlay - For Model
	Backlight_BgBlurOverModel,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Blur BG overlay - For Background
	Backlight_BgBlurOverBg,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.4
	// explanation: Model color darken
	Backlight_DarkenModel,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Background color darken
	Backlight_DarkenBg,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 1
	// explanation: Backlight strength - Main
	Backlight_StrengthNormal,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.7
	// explanation: Backlight strength - Directional
	Backlight_StrengthDirectional,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.9
	// explanation: Backlight brightness limit
	Backlight_BrightnessLimit,

	// type: Float, sets_active: False
	// min: 0, max: 360
	// default: 45
	// explanation: Backlight direction
	Backlight_BacklightDirection,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: Backlight dir. both sides
	Backlight_BacklightBothDirections,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.8
	// explanation: Backlight softness
	Backlight_BacklightSoftness,

	// type: Color, sets_active: False
	// default: 5E3E96 alpha: False
	// explanation: Backlight color tint
	Backlight_BacklightColorTint,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.2
	// explanation: Backlight col. from background
	Backlight_BacklightColorFromBg,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Outline size
	Backlight_OutlineSize,

	// type: Color, sets_active: False
	// default: DD103C alpha: True
	// explanation: Outline color
	Backlight_OutlineColorMain,

	// type: Color, sets_active: False
	// default: 070001 alpha: True
	// explanation: Outline stripe color
	Backlight_OutlineColorStripes,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: Outline stripe count
	Backlight_OutlineStripeCount,

	// type: Float, sets_active: False
	// min: -1, max: 1
	// default: 0.2
	// explanation: Outline stripe speed
	Backlight_OutlineStripeSpeed,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Outline stripe curve
	Backlight_OutlineStripeCurve,

	// type: Color, sets_active: False
	// default: 08090C alpha: True
	// explanation: Shadow color
	Backlight_ShadowMainColor,

	// type: Float, sets_active: False
	// min: -10, max: 10
	// default: 0
	// explanation: Shadow offset X
	Backlight_ShadowOffsetX,

	// type: Float, sets_active: False
	// min: -10, max: 10
	// default: 0
	// explanation: Shadow offset Y
	Backlight_ShadowOffsetY,



	// --------- Effect: CustomParticles -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off - Multiplier for opacity
	CustomParticles_Strength,

	// type: Float, sets_active: False
	// min: -1, max: 1
	// default: -0.4
	// explanation: [All] Move with head movement
	CustomParticles_BaseMoveWithHead,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 1
	// explanation: [Sparkle] Amount
	CustomParticles_SparkleStrength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.4
	// explanation: [Sparkle] Size
	CustomParticles_SparkleSize,

	// type: Color, sets_active: False
	// default: FF0000 alpha: True
	// explanation: [Sparkle] Color A
	CustomParticles_SparkleColorA,

	// type: Color, sets_active: False
	// default: E13457 alpha: True
	// explanation: [Sparkle] Color B
	CustomParticles_SparkleColorB,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.4
	// explanation: [Floaty particles] Amount
	CustomParticles_FloatyStrength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.2
	// explanation: [Floaty particles] Size
	CustomParticles_FloatySize,

	// type: Color, sets_active: False
	// default: 5F3ACE alpha: True
	// explanation: [Floaty particles] Color A
	CustomParticles_FloatyColorA,

	// type: Color, sets_active: False
	// default: F8899F alpha: True
	// explanation: [Floaty particles] Color B
	CustomParticles_FloatyColorB,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 1
	// explanation: [Fog] Amount
	CustomParticles_CloudStrength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: [Fog] Size
	CustomParticles_CloudSize,

	// type: Color, sets_active: False
	// default: 832525 alpha: True
	// explanation: [Fog] Color A
	CustomParticles_CloudColorA,

	// type: Color, sets_active: False
	// default: C83ACE alpha: True
	// explanation: [Fog] Color B
	CustomParticles_CloudColorB,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.2
	// explanation: [Light spheres] Amount
	CustomParticles_SphereStrength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.8
	// explanation: [Light spheres] Size
	CustomParticles_SphereSize,

	// type: Color, sets_active: False
	// default: 3037E9 alpha: True
	// explanation: [Light spheres] Color A
	CustomParticles_SphereColorA,

	// type: Color, sets_active: False
	// default: E810AC alpha: True
	// explanation: [Light spheres] Color B
	CustomParticles_SphereColorB,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.3
	// explanation: [Hearts] Amount
	CustomParticles_HeartsStrength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: [Hearts] Size
	CustomParticles_HeartsSize,

	// type: Color, sets_active: False
	// default: FF1262 alpha: True
	// explanation: [Hearts] Color A
	CustomParticles_HeartsColorA,

	// type: Color, sets_active: False
	// default: FF0031 alpha: True
	// explanation: [Hearts] Color B
	CustomParticles_HeartsColorB,

	// type: SceneItem, sets_active: False
	// default: 
	// explanation: [Custom 1] Texture file
	CustomParticles_Custom1TextureFile,

	// type: Color, sets_active: False
	// default: FFFFFF alpha: True
	// explanation: [Custom 1] Color A
	CustomParticles_Custom1ColorA,

	// type: Color, sets_active: False
	// default: FFFFFF alpha: True
	// explanation: [Custom 1] Color B
	CustomParticles_Custom1ColorB,

	// type: Bool, sets_active: False
	// default: False
	// explanation: [Custom 1] Additive Particles - Will make particles shiny
	CustomParticles_Custom1MaterialTypeId,

	// type: Bool, sets_active: False
	// default: False
	// explanation: [Custom 1] Show behind model
	CustomParticles_Custom1InBack,

	// type: Float, sets_active: False
	// min: -1, max: 1
	// default: -0.5
	// explanation: [Custom 1] Move with head movement
	CustomParticles_Custom1MoveWithHead,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: [Custom 1] Size
	CustomParticles_Custom1Size,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: [Custom 1] Amount
	CustomParticles_Custom1Amount,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.3
	// explanation: [Custom 1] Fill to center
	CustomParticles_Custom1FillToCenter,

	// type: Float, sets_active: False
	// min: 0, max: 180
	// default: 15
	// explanation: [Custom 1] Base Rotation
	CustomParticles_Custom1BaseRotation,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: [Custom 1] Rotation Speed
	CustomParticles_Custom1RotationSpeed,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.3
	// explanation: [Custom 1] Microphone effect - Microphone volume moves particles faster
	CustomParticles_Custom1MoveFasterMicVol,

	// type: SceneItem, sets_active: False
	// default: 
	// explanation: [Custom 2] Texture file
	CustomParticles_Custom2TextureFile,

	// type: Color, sets_active: False
	// default: FFFFFF alpha: True
	// explanation: [Custom 2] Color A
	CustomParticles_Custom2ColorA,

	// type: Color, sets_active: False
	// default: FFFFFF alpha: True
	// explanation: [Custom 2] Color B
	CustomParticles_Custom2ColorB,

	// type: Bool, sets_active: False
	// default: False
	// explanation: [Custom 2] Additive Particles - Will make particles shiny
	CustomParticles_Custom2MaterialTypeId,

	// type: Bool, sets_active: False
	// default: False
	// explanation: [Custom 2] Show behind model
	CustomParticles_Custom2InBack,

	// type: Float, sets_active: False
	// min: -1, max: 1
	// default: -0.5
	// explanation: [Custom 2] Move with head movement
	CustomParticles_Custom2MoveWithHead,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: [Custom 2] Size
	CustomParticles_Custom2Size,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: [Custom 2] Amount
	CustomParticles_Custom2Amount,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.3
	// explanation: [Custom 2] Fill to center
	CustomParticles_Custom2FillToCenter,

	// type: Float, sets_active: False
	// min: 0, max: 180
	// default: 15
	// explanation: [Custom 2] Base Rotation
	CustomParticles_Custom2BaseRotation,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: [Custom 2] Rotation Speed
	CustomParticles_Custom2RotationSpeed,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.3
	// explanation: [Custom 2] Microphone effect - Microphone volume moves particles faster
	CustomParticles_Custom2MoveFasterMicVol,



	// --------- Effect: BackgroundShift -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	BackgroundShift_Strength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.3
	// explanation: Zoom in
	BackgroundShift_ZoomIn,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Microphone effect - Microphone volume zooms in
	BackgroundShift_MicZoomIn,

	// type: Float, sets_active: False
	// min: -2, max: 2
	// default: 0.5
	// explanation: Move from X tracking
	BackgroundShift_TrackingX,

	// type: Float, sets_active: False
	// min: -2, max: 2
	// default: 0.5
	// explanation: Move from Y tracking
	BackgroundShift_TrackingY,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.3
	// explanation: Tracking movement smoothing
	BackgroundShift_TrackingSmoothing,

	// type: Float, sets_active: False
	// min: 0, max: 2
	// default: 0.5
	// explanation: Move X randomly
	BackgroundShift_RandomMovementX,

	// type: Float, sets_active: False
	// min: 0, max: 2
	// default: 0.5
	// explanation: Move Y randomly
	BackgroundShift_RandomMovementY,

	// type: Float, sets_active: False
	// min: 0, max: 2
	// default: 0.15
	// explanation: Rotate randomly
	BackgroundShift_RandomMovementRotation,

	// type: Float, sets_active: False
	// min: 0.01, max: 2
	// default: 0.2
	// explanation: Random movement speed
	BackgroundShift_RandomMovementSpeed,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Blur back visibility
	BackgroundShift_BlurMixBack,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Blur back strength
	BackgroundShift_BlurMainBack,

	// type: Float, sets_active: False
	// min: -3, max: 3
	// default: 1
	// explanation: Blur back brightness
	BackgroundShift_BlurBrightnessBack,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Blur front visibility
	BackgroundShift_BlurMixFront,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Blur front strength
	BackgroundShift_BlurMainFront,

	// type: Float, sets_active: False
	// min: -3, max: 3
	// default: 1
	// explanation: Blur front brightness
	BackgroundShift_BlurBrightnessFront,



	// --------- Effect: SimpleOverlay -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off - Multiplier for opacity
	SimpleOverlay_Strength,

	// type: SceneItem, sets_active: False
	// default: 
	// explanation: Overlay image file
	SimpleOverlay_TextureFile,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.35
	// explanation: Zoom in
	SimpleOverlay_ZoomIn,

	// type: Float, sets_active: False
	// min: -2, max: 2
	// default: -0.5
	// explanation: Move from X tracking
	SimpleOverlay_TrackingX,

	// type: Float, sets_active: False
	// min: -2, max: 2
	// default: -0.5
	// explanation: Move from Y tracking
	SimpleOverlay_TrackingY,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.3
	// explanation: Tracking movement smoothing
	SimpleOverlay_TrackingSmoothing,

	// type: Float, sets_active: False
	// min: 0, max: 2
	// default: 0.4
	// explanation: Move X randomly
	SimpleOverlay_RandomMovementX,

	// type: Float, sets_active: False
	// min: 0, max: 2
	// default: 0.4
	// explanation: Move Y randomly
	SimpleOverlay_RandomMovementY,

	// type: Float, sets_active: False
	// min: 0, max: 2
	// default: 0.1
	// explanation: Rotate randomly
	SimpleOverlay_RandomMovementRotation,

	// type: Float, sets_active: False
	// min: 0.01, max: 2
	// default: 0.2
	// explanation: Random movement speed
	SimpleOverlay_RandomMovementSpeed,

	// type: Color, sets_active: False
	// default: FFFFFF alpha: True
	// explanation: Tint color
	SimpleOverlay_TintColor,



	// --------- Effect: Vignette -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	Vignette_Strength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.9
	// explanation: Smoothness
	Vignette_Smoothness,

	// type: Color, sets_active: False
	// default: 000000 alpha: True
	// explanation: Color
	Vignette_Color,

	// type: Float, sets_active: False
	// min: -1, max: 1
	// default: 0
	// explanation: Center X
	Vignette_CenterX,

	// type: Float, sets_active: False
	// min: -1, max: 1
	// default: 0
	// explanation: Center Y
	Vignette_CenterY,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 1
	// explanation: Roundness
	Vignette_Roundness,

	// type: Bool, sets_active: False
	// default: False
	// explanation: Even side length
	Vignette_Circular,



	// --------- Effect: ChromaticAberration -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	ChromaticAberration_Strength,

	// type: Bool, sets_active: False
	// default: True
	// explanation: Blur edges
	ChromaticAberration_BlurEdges,



	// --------- Effect: OldFilm -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	OldFilm_Strength,

	// type: Float, sets_active: False
	// min: 0, max: 30
	// default: 15
	// explanation: FPS limit
	OldFilm_FilmFps,

	// type: Float, sets_active: False
	// min: 0, max: 5
	// default: 1
	// explanation: Contrast
	OldFilm_FilmContrast,

	// type: Float, sets_active: False
	// min: 0, max: 4
	// default: 0.9
	// explanation: Film burn
	OldFilm_FilmBurn,

	// type: Float, sets_active: False
	// min: 0, max: 2
	// default: 0.9
	// explanation: Film dirt size
	OldFilm_FilmSceneCut,



	// --------- Effect: Lowfps -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	Lowfps_Strength,

	// type: Int, sets_active: False
	// min: 1, max: 60
	// default: 15
	// explanation: FPS limit
	Lowfps_FpsLimit,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: FPS jitter strength
	Lowfps_FpsRandom,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Screen tearing
	Lowfps_ScreenTearing,



	// --------- Effect: Datamosh -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	Datamosh_Strength,

	// type: Int, sets_active: False
	// min: 1, max: 200
	// default: 16
	// explanation: Size
	Datamosh_Size,

	// type: Float, sets_active: False
	// min: 0, max: 60
	// default: 3
	// explanation: Reset after seconds
	Datamosh_ResetAfterSecs,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: Entropy
	Datamosh_Entropy,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: Noise Contrast
	Datamosh_NoiseContrast,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: Velocity Scale
	Datamosh_VelocityScale,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: Diffusion
	Datamosh_Diffusion,



	// --------- Effect: LineScanner -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	LineScanner_Strength,

	// type: Int, sets_active: False
	// min: 1, max: 4
	// default: 1
	// explanation: Direction
	LineScanner_Direction,

	// type: Int, sets_active: False
	// min: 16, max: 2048
	// default: 1024
	// explanation: Total scan steps
	LineScanner_ScanStepTotal,

	// type: Int, sets_active: False
	// min: 1, max: 16
	// default: 4
	// explanation: Scan step size
	LineScanner_ScanStepSize,

	// type: Color, sets_active: False
	// default: 0C0001 alpha: True
	// explanation: Scan line color
	LineScanner_ScanLineColor,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.15
	// explanation: Scan line size
	LineScanner_ScanLineSize,

	// type: Float, sets_active: False
	// min: 0, max: 30
	// default: 3
	// explanation: Wait between scans - Reset after seconds
	LineScanner_ScanLineWaitBetweenScansSecs,



	// --------- Effect: ParticleShower -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off - Multiplier for opacity
	ParticleShower_Strength,

	// type: SceneItem, sets_active: False
	// default: 
	// explanation: [Custom 1] Texture file
	ParticleShower_TextureFile1,

	// type: SceneItem, sets_active: False
	// default: 
	// explanation: [Custom 2] Texture file
	ParticleShower_TextureFile2,

	// type: SceneItem, sets_active: False
	// default: 
	// explanation: [Custom 3] Texture file
	ParticleShower_TextureFile3,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.4
	// explanation: [Custom 1] Fall speed
	ParticleShower_Speed1,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.4
	// explanation: [Custom 2] Fall speed
	ParticleShower_Speed2,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.4
	// explanation: [Custom 3] Fall speed
	ParticleShower_Speed3,

	// type: Bool, sets_active: False
	// default: False
	// explanation: [Custom 1] Show behind model
	ParticleShower_InBack1,

	// type: Bool, sets_active: False
	// default: False
	// explanation: [Custom 2] Show behind model
	ParticleShower_InBack2,

	// type: Bool, sets_active: False
	// default: False
	// explanation: [Custom 3] Show behind model
	ParticleShower_InBack3,



	// --------- Effect: AnalogGlitch -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	AnalogGlitch_Strength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Scanline Jitter
	AnalogGlitch_ScanlineJitter,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Vertical jump
	AnalogGlitch_VerticalJump,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Horizontal shake
	AnalogGlitch_HorizontalShake,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Color Drift
	AnalogGlitch_ColorDrift,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Microphone effect - Microphone volume boosts strength
	AnalogGlitch_MicEffect,



	// --------- Effect: DigitalGlitch -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Strength - Strength of the effect
	DigitalGlitch_Strength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Color Shift - How much to shift the color for this effect?
	DigitalGlitch_Colorshift,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Microphone effect - Microphone volume boosts strength
	DigitalGlitch_MicEffect,



	// --------- Effect: Letterbox -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	Letterbox_Strength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.3
	// explanation: Letterbox Y
	Letterbox_ProgressY,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Letterbox X
	Letterbox_ProgressX,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Zoom in
	Letterbox_Zoom,

	// type: Color, sets_active: False
	// default: 000000 alpha: True
	// explanation: Tint color
	Letterbox_Color,



	// --------- Effect: FoggyWindow -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	FoggyWindow_Strength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: Fog amount
	FoggyWindow_FogStrength,

	// type: Color, sets_active: False
	// default: 3AABEE alpha: True
	// explanation: Fog color tint
	FoggyWindow_FogTint,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.6
	// explanation: Fog brightness boost
	FoggyWindow_FogBoost,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.8
	// explanation: Raindrop visibility
	FoggyWindow_RaindropVisibility,

	// type: Float, sets_active: False
	// min: -1, max: 1
	// default: 0.2
	// explanation: Raindrop speed
	FoggyWindow_RaindropSpeed,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.8
	// explanation: Raindrop size
	FoggyWindow_RaindropSize,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.2
	// explanation: Fog wipe size
	FoggyWindow_FogWipeSize,

	// type: Float, sets_active: False
	// min: 2, max: 30
	// default: 5
	// explanation: Fog wipe seconds
	FoggyWindow_FogWipeLifetimeSeconds,

	// type: Bool, sets_active: False
	// default: False
	// explanation: Wiped fog stays wiped
	FoggyWindow_FogLifetimeInfinite,



	// --------- Effect: Speedlines -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	Speedlines_Strength,

	// type: Float, sets_active: False
	// min: -1, max: 1
	// default: 0
	// explanation: X center
	Speedlines_XCenter,

	// type: Float, sets_active: False
	// min: -1, max: 1
	// default: 0
	// explanation: Y center
	Speedlines_YCenter,

	// type: Color, sets_active: False
	// default: EDEBF8 alpha: True
	// explanation: Speedlines color A
	Speedlines_ColorA,

	// type: Color, sets_active: False
	// default: 110101 alpha: True
	// explanation: Speedlines color B
	Speedlines_ColorB,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Microphone effect - Microphone volume boosts strength
	Speedlines_MicEffect,



	// --------- Effect: Pixelation -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	Pixelation_Strength,

	// type: Int, sets_active: False
	// min: 10, max: 600
	// default: 128
	// explanation: Resolution
	Pixelation_Resolution,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 1
	// explanation: Color filter
	Pixelation_Colorize,

	// type: Color, sets_active: False
	// default: 241A1A alpha: True
	// explanation: Color  1
	Pixelation_C1,

	// type: Color, sets_active: False
	// default: 3F2C2C alpha: True
	// explanation: Color  2
	Pixelation_C2,

	// type: Color, sets_active: False
	// default: 7D4C4C alpha: True
	// explanation: Color  3
	Pixelation_C3,

	// type: Color, sets_active: False
	// default: 9C6161 alpha: True
	// explanation: Color  4
	Pixelation_C4,

	// type: Color, sets_active: False
	// default: B08282 alpha: True
	// explanation: Color  5
	Pixelation_C5,

	// type: Color, sets_active: False
	// default: E5BDBD alpha: True
	// explanation: Color  6
	Pixelation_C6,

	// type: Color, sets_active: False
	// default: E9D5D5 alpha: True
	// explanation: Color  7
	Pixelation_C7,

	// type: Color, sets_active: False
	// default: FEFEFE alpha: True
	// explanation: Color  8
	Pixelation_C8,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Fry
	Pixelation_Fry,



	// --------- Effect: LensDistortion -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	LensDistortion_Strength,

	// type: Float, sets_active: False
	// min: -1, max: 1
	// default: 0
	// explanation: Lens strength
	LensDistortion_LensStrength,

	// type: Float, sets_active: False
	// min: -1, max: 1
	// default: 0
	// explanation: Zoom in
	LensDistortion_ZoomIn,

	// type: Float, sets_active: False
	// min: -1, max: 1
	// default: 0
	// explanation: Squish
	LensDistortion_Squish,



	// --------- Effect: WaveDistortion -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	WaveDistortion_Strength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.2
	// explanation: Heat wave strength
	WaveDistortion_HeatStrength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.4
	// explanation: Raindrop strength
	WaveDistortion_RaindropStrength,

	// type: Float, sets_active: False
	// min: 1, max: 5
	// default: 1.6
	// explanation: Raindrop interval (sec)
	WaveDistortion_RaindropFrequency,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Zoom in
	WaveDistortion_ZoomIn,

	// type: Float, sets_active: False
	// min: -180, max: 180
	// default: 0
	// explanation: Base Rotation
	WaveDistortion_RotationBase,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.1
	// explanation: Wave strength X
	WaveDistortion_WaveXStrength,

	// type: Float, sets_active: False
	// min: -1, max: 1
	// default: 0.5
	// explanation: Wave scroll X
	WaveDistortion_WaveXScroll,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: Wave frequency X
	WaveDistortion_WaveXFrequency,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.1
	// explanation: Wave strength Y
	WaveDistortion_WaveYStrength,

	// type: Float, sets_active: False
	// min: -1, max: 1
	// default: 0.5
	// explanation: Wave scroll Y
	WaveDistortion_WaveYScroll,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: Wave frequency Y
	WaveDistortion_WaveYFrequency,



	// --------- Effect: BlurEffects -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	BlurEffects_Strength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Blur visibility
	BlurEffects_BasicBlurVisibility,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Blur strength
	BlurEffects_BasicBlurStrength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Pixelation
	BlurEffects_PixelationBlur,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Motion blur
	BlurEffects_MotionBlur,



	// --------- Effect: Grain -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	Grain_Strength,

	// type: Float, sets_active: False
	// min: 0.1, max: 3
	// default: 1.7
	// explanation: Size
	Grain_Size,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: Luminosity
	Grain_Luminosity,

	// type: Bool, sets_active: False
	// default: False
	// explanation: Colored
	Grain_Colored,



	// --------- Effect: Vhs -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	Vhs_Strength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 1
	// explanation: Monitor fisheye
	Vhs_Fisheye,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.2
	// explanation: Vignette
	Vhs_Vignette,

	// type: Float, sets_active: False
	// min: 0, max: 5
	// default: 1
	// explanation: Sideways blur
	Vhs_ScreenBleed,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: Grain noise
	Vhs_NoiseGrain,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.5
	// explanation: Line noise
	Vhs_NoiseLines,

	// type: Float, sets_active: False
	// min: 0, max: 5
	// default: 1
	// explanation: Horizontal twitch (up/down)
	Vhs_TwitchVertical,

	// type: Float, sets_active: False
	// min: 0, max: 5
	// default: 1
	// explanation: Vertical twitch (left/right)
	Vhs_TwitchHorizontal,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.1
	// explanation: Interlacing
	Vhs_Interlacing,

	// type: Float, sets_active: False
	// min: -1, max: 1
	// default: 0
	// explanation: Gamma correction
	Vhs_GammaCorrection,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.2
	// explanation: Pale color
	Vhs_PaleColor,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Afterimage strength
	Vhs_AfterImageAmount,

	// type: Color, sets_active: False
	// default: FF6202 alpha: False
	// explanation: Afterimage color
	Vhs_AfterImageColor,



	// --------- Effect: Outline -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	Outline_Strength,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Sharpen image
	Outline_Sharpen,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Outline visibility
	Outline_Visibility,

	// type: Color, sets_active: False
	// default: 000000 alpha: True
	// explanation: Outline color
	Outline_Color,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.9
	// explanation: Outline threshold
	Outline_Threshold,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0.2
	// explanation: Outline contrast
	Outline_Contrast,



	// --------- Effect: Posterize -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	Posterize_Strength,



	// --------- Effect: Ascii -------------------------

	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Effect on/off
	Ascii_Strength,

	// type: Float, sets_active: False
	// min: 0, max: 10
	// default: 3
	// explanation: Size
	Ascii_Size,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 1
	// explanation: Character visibility
	Ascii_CharacterVisibility,

	// type: Float, sets_active: False
	// min: 0, max: 1
	// default: 0
	// explanation: Color overlay strength
	Ascii_CharacterColorStrength,

	// type: Color, sets_active: False
	// default: 1EB916 alpha: False
	// explanation: Color overlay
	Ascii_CharacterColor,



	// --------- Effect: ModelGlitch -------------------------

	// RESTRICTED EXPERIMENTAL EFFECT
	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Explode model parts
	ModelGlitch_StrengthExplode,

	// RESTRICTED EXPERIMENTAL EFFECT
	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Wiggle model parts
	ModelGlitch_StrengthWiggle,

	// RESTRICTED EXPERIMENTAL EFFECT
	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Pulsate model parts
	ModelGlitch_StrengthPulse,

	// RESTRICTED EXPERIMENTAL EFFECT
	// type: Float, sets_active: True
	// min: 0, max: 1
	// default: 0
	// explanation: Liquify model parts
	ModelGlitch_StrengthLiquify
}
