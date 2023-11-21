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
float3 lightPos;

//float3 AmbientColor = float3(0.15, 0.15, 0.15);
float3 lightDirection = float3(1,1,1);
float3 lightColor = float3(1, 1, 1);

struct VertexShaderInput
{
	float4 Position : POSITION0;
    float2 TexCoord : TEXCOORD0;
    float3 Normal : NORMAL0;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
    float2 TexCoord : TEXCOORD0;
    float3 Normal : NORMAL0;
};

VertexShaderOutput MainVS(in VertexShaderInput input)
{
	VertexShaderOutput output = (VertexShaderOutput)0;

	output.Position = mul(input.Position, WorldViewProjection);
    output.TexCoord = input.TexCoord;
    output.Normal = normalize(input.Normal);
	
	return output;
}


float4 MainPS(VertexShaderOutput input) : COLOR
{
    float3 diffuse = (float3)tex2D(Tex, input.TexCoord);
    float3 lightDir = normalize(lightDirection);
    float3 lambertian = saturate(dot(lightDir, input.Normal)) * lightColor;
    float3 refl = reflect(lightDir, input.Normal);
    lambertian += pow(saturate(dot(relf, input.viewDir)), specPower) * specColor;
	float3 output = saturate(lambertian) * diffuse;
	return float4(output, 1);
}

technique BasicColorDrawing
{
	pass P0
	{
		VertexShader = compile VS_SHADERMODEL MainVS();
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};