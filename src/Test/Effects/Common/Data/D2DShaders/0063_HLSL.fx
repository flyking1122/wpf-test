

//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//

//
// Samplers...
//

sampler SampleTextureFromInterpolatorUV1_Sampler;

//
// Vertex Shader Stage Data
//

struct VS_STAGE_DATA
{
   float2 UV;
   float4 Color;
};

//
// Vertex Fragment Data...
//

struct Transform_World2D_By_Matrix4x4_VS0_VS_ConstData
{
    float4x4 mat4x4WorldToProjection;
};

//
// Vertex Shader Constant Data
//

struct VertexShaderConstantData
{
    Transform_World2D_By_Matrix4x4_VS0_VS_ConstData Transform_World2D_By_Matrix4x4_VS0_ConstantTable;
};

cbuffer cbVSUpdateEveryCall
{
    VertexShaderConstantData Data_VS;
};

//
// Pixel Shader Stage Data
//

struct PS_STAGE_DATA
{
   float4 Color;
};

//
// Pixel Fragment Data...
//

struct SetColorValue_PS2_PS_ConstData
{
    float4 color;

};

//
// Pixel Shader Constant Data
//

struct PixelShaderConstantData
{
    SetColorValue_PS2_PS_ConstData SetColorValue_PS2_ConstantTable;
};

cbuffer cbPSUpdateEveryCall
{
    PixelShaderConstantData Data_PS;
};


struct VertexShaderOutput
{
    float4 Position : SV_POSITION;
    float4 Diffuse  : TEXCOORD0;
    float2 UV_0 : TEXCOORD1;
};

//
// Fragment Vertex Shader functions...
//
void
Transform_World2D_By_Matrix4x4_VS0(
    float3 WorldPos2D,
    Transform_World2D_By_Matrix4x4_VS0_VS_ConstData Data,
    inout VertexShaderOutput Output
    )
{
    Output.Diffuse = float4(1.0, 1.0, 1.0, 1.0);
    Output.Position = mul(float4(WorldPos2D, 1.0f), Data.mat4x4WorldToProjection);
}
void
SetVertexStageUVToInputUV_VS1(
    float2 UV,
    inout VS_STAGE_DATA vsStageData
    )
{
    vsStageData.UV = UV;
}
void
MoveVertexStageUVToInterpolator_VS1(
    VS_STAGE_DATA vsStageData,
    inout float2 uv
    )
{
    uv = vsStageData.UV;
}


//
// Main Vertex Shader
//



VertexShaderOutput
VS(
    float3 Position : POSITION,
    float4 Diffuse : TEXCOORD0,
    float2 UV_0 : TEXCOORD1,
    float2 UV_1 : TEXCOORD2
    )
{
    VertexShaderOutput Output = (VertexShaderOutput)0;

    // These will be optimized away when not in use
    float4x4      View, WorldView, WorldViewProj, WorldViewAdjTrans;
    float         SpecularPower;
    VS_STAGE_DATA vsStageData;


    vsStageData.Color = float4(1.0 , 1.0, 1.0, 1.0);
    vsStageData.UV = float2(0.0, 0.0);

    Transform_World2D_By_Matrix4x4_VS0(
        Position,
        Data_VS.Transform_World2D_By_Matrix4x4_VS0_ConstantTable,
        Output
        );

    vsStageData.Color = float4(1.0 , 1.0, 1.0, 1.0);
    vsStageData.UV = float2(0.0, 0.0);

    SetVertexStageUVToInputUV_VS1(
        UV_0,
        vsStageData
        );

    MoveVertexStageUVToInterpolator_VS1(
        vsStageData,
        Output.UV_0
        );

    Output.Diffuse.rgb = min(Output.Diffuse.rgb, 1.0);

    return Output;
};

//
// Fragment Pixel Shader fragments...
//
void
SampleTextureFromInterpolatorUV_PS1(
    sampler TextureSampler,
    float2 uv,
    inout PS_STAGE_DATA psStageData
    )
{
    psStageData.Color = tex2D(TextureSampler, uv);
}
void
MakeOpaque_PS1(
    inout PS_STAGE_DATA psStageData
    )
{
    psStageData.Color.a = 1.0;
}
void
Multiply_Premultiplied_Color_PS1(
    PS_STAGE_DATA psStageData,
    inout float4 curPixelColor
    )
{
    curPixelColor *= psStageData.Color;
}
void
SetColorValue_PS2(
    SetColorValue_PS2_PS_ConstData data,
    inout PS_STAGE_DATA psStageData
    )
{
    psStageData.Color = data.color;
}
void
Multiply_AlphaOnly_NonPremultiplied_PS2(
    PS_STAGE_DATA psStageData,
    inout float4 curPixelColor
    )
{
    curPixelColor.a *= psStageData.Color.a;
}


//
// Main Pixel Shader
//


float4
PS(
    float4 Position : SV_POSITION,
    float4 Diffuse  : TEXCOORD0,
    float2 UV_0 : TEXCOORD1
    ) : SV_Target
{
    float4        curColor = Diffuse;
    PS_STAGE_DATA psStageData;

    psStageData.Color = float4(1.0 , 1.0, 1.0, 1.0);

    SampleTextureFromInterpolatorUV_PS1(
        SampleTextureFromInterpolatorUV1_Sampler,
        UV_0,
        psStageData        );

    MakeOpaque_PS1(
        psStageData        );

    Multiply_Premultiplied_Color_PS1(
        psStageData,
        curColor
        );

    psStageData.Color = float4(1.0 , 1.0, 1.0, 1.0);

    SetColorValue_PS2(
        Data_PS.SetColorValue_PS2_ConstantTable,
        psStageData        );

    Multiply_AlphaOnly_NonPremultiplied_PS2(
        psStageData,
        curColor
        );

    return curColor;
};

//
// Technique
//

technique T0
{
    pass P0
    {
        SetVertexShader( CompileShader( vs_4_0, VS() ) );
        SetGeometryShader( NULL );
        SetPixelShader( CompileShader( ps_4_0, PS() ) );
    }
}

//
// End of Dynamic Shader Code
//
