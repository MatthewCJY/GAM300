/*!*************************************************************************
****
\file boxCollider.cpp
\author Go Ruo Yan
\par DP email: ruoyan.go@digipen.edu
\date 21-10-2023
\brief  This program defines the functions in the Box Collider component 
		class
****************************************************************************
***/

#include "components/boxCollider.h"

RTTR_REGISTRATION
{
	using namespace TDS;

	rttr::registration::class_<BoxCollider>("Box Collider")
		.method("GetIsTrigger", &BoxCollider::GetIsTrigger)
		.method("SetIsTrigger", &BoxCollider::SetIsTrigger)
		.property("IsTrigger", &BoxCollider::mIsTrigger)
		.method("GetCenter", &BoxCollider::GetCenter)
		.method("SetCenter", rttr::select_overload<void(Vec3)>(&BoxCollider::SetCenter))
		.method("SetCenter", rttr::select_overload<void(float, float, float)>(&BoxCollider::SetCenter))
		.property("Center", &BoxCollider::mCenter)
		.method("GetSize", &BoxCollider::GetSize)
		.method("SetSize", rttr::select_overload<void(Vec3)>(&BoxCollider::SetSize))
		.method("SetSize", rttr::select_overload<void(float, float, float)>(&BoxCollider::SetSize))
		.property("Size", &BoxCollider::mSize);
}

namespace TDS
{
	/*!*************************************************************************
	Initializes the Collider component when created
	****************************************************************************/
	BoxCollider::BoxCollider() : mIsTrigger		(false),
								 mCenter		(Vec3(0.0f, 0.0f, 0.0f)),
								 mSize			(Vec3(0.0f, 0.0f, 0.0f))
	{ }

	/*!*************************************************************************
	Initializes the Collider component when created, given another Collider
	component to move (for ECS)
	****************************************************************************/
	BoxCollider::BoxCollider(BoxCollider&& toMove) noexcept : mIsTrigger	(toMove.mIsTrigger),
															  mCenter		(toMove.mCenter),
															  mSize			(toMove.mSize)
	{ }

	BoxCollider* GetBoxCollider(EntityID entityID)
	{
		return ecs.getComponent<BoxCollider>(entityID);
	}
}