#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

matrix WorldViewProjection;
sampler2D Tex;

struct VertexShaderInput
{
	float4 Position : POSITION0;
    float2 TexCoord : TEXCOORD0;
};

struct VertexShaderOutput
{
    float4 Position : POSITION0;
    float4 WorldPosition : TEXCOORD0;
    float2 TexCoord : TEXCOORD1;
};

VertexShaderOutput MainVS(in VertexShaderInput input)
{
	VertexShaderOutput output = (VertexShaderOutput)0;

	output.Position = mul(input.Position, WorldViewProjection);
    output.WorldPosition = output.Position;
    output.TexCoord = input.TexCoord;
	
    return output;
}

struct PixelInput
{
    float4 Position : POSITION0;
    float4 WorldPosition : TEXCOORD0; 
    float2 TexCoord : TEXCOORD1;
};

float4 MainPS(PixelInput input) : COLOR0
{
     // Access the world position in the pixel shader
    float3 worldPosition = input.WorldPosition.xyz;
    float2 texCoord = input.TexCoord;

    // Calculate color based on world position
    float red = saturate(worldPosition.x);
    float green = saturate(worldPosition.y);
    float blue = saturate(worldPosition.z);

    float4 textureColor = tex2D(Tex, texCoord);
    
    return float4(red * textureColor.r, green * textureColor.g, blue * textureColor.b, 1.0);
}

technique BasicColorDrawing
{
	pass P0
	{
		VertexShader = compile VS_SHADERMODEL MainVS();
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};