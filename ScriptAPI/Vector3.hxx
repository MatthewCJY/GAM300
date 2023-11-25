#pragma once
#include "../Shared_Libs/Vector3.h"

namespace ScriptAPI
{
	public value class Vector3
	{
	public:
		property float X;
		property float Y;
		property float Z;

		Vector3(float valueX, float valueY, float valueZ);
		Vector3(TDS::Vec3 value);

		static Vector3 operator+(Vector3 lhs, Vector3 rhs);

		static Vector3 operator-(Vector3 lhs, Vector3 rhs);
		static Vector3 operator*(Vector3 lhs, Vector3 rhs);
		static Vector3 operator*(Vector3 lhs, float rhs);
		void Normalize();
		Vector3 normalise();
	};
}