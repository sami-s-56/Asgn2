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

float specPower = 4;
float3 specColor = float3(0, 0, 1);

float3 camPos;
matrix world;

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
    float3 ViewDir : TEXCOORD1;
};

VertexShaderOutput MainVS(in VertexShaderInput input)
{
	VertexShaderOutput output = (VertexShaderOutput)0;

    float4 worldP = mul(input.Position, world);
	
	output.Position = mul(input.Position, WorldViewProjection);
    output.TexCoord = input.TexCoord;
	//output.Normal = normalize(input.Normal);
    
	output.Normal = normalize(mul(input.Normal, world));
    output.ViewDir = normalize(worldP - camPos);
	
	return output;
}

float4 MainPS(VertexShaderOutput input) : COLOR
{
    float3 diffuse = (float3)tex2D(Tex, input.TexCoord);
    float3 lightDir = normalize(lightDirection);
    float3 lambertian = saturate(dot(lightDir, input.Normal)) * lightColor;
    float3 refl = reflect(lightDir, input.Normal);
    lambertian += pow(saturate(dot(refl, input.ViewDir)), specPower) * specColor;
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