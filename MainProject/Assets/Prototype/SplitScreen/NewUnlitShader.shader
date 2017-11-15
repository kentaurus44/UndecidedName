// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Kentaurus/NewUnlitShader"
{
	Properties
	{
		_MainTex ("First", 2D) = "white" {}
		_SecondTex ("Second", 2D) = "white" {}
		_Splitter ("Splitter", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }

		Blend SrcAlpha OneMinusSrcAlpha
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float2 uv2 : TEXCOORD1;
				float2 uv3 : TEXCOORD2;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float2 uv2 : TEXCOORD1;
				float2 uv3 : TEXCOORD2;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _SecondTex;
			sampler2D _Splitter;
			float4 _MainTex_ST;
			float4 _SecondTex_ST;
			float4 _Splitter_ST;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv2 = TRANSFORM_TEX(v.uv2, _SecondTex);
				o.uv3 = TRANSFORM_TEX(v.uv3, _Splitter);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 col2 = tex2D(_SecondTex, i.uv2);
				fixed4 ret = tex2D(_Splitter, i.uv3);

				col = fixed4(min(col.r, ret.r), min(col.g, ret.r), min(col.b, ret.r), 1);
				col2 = fixed4(min(col2.r, ret.g), min(col2.g, ret.g), min(col2.b, ret.g), 1);

				return col + col2;
			}
			ENDCG
		}
	}
}
