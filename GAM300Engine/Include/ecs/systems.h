/*!*************************************************************************
****
\file systems.h
\author Go Ruo Yan
\par DP email: ruoyan.go@digipen.edu
\date 28-9-2023
\brief  This program declares and registers the systems in the ECS
****************************************************************************
***/

#ifndef SYSTEMS
#define SYSTEMS

#include "ecs/ecs.h"
#include "components/components.h"

// DONT INCLUDE THIS ANYWHERE BUT ECS.CPP

namespace TDS
{
	DLL_API ECS ecs;

	//std::unique_ptr<ECS> ECS::m_instance;

	ECSSystem<Transform, RigidBody>					_PhysicsSystem(1);
	ECSSystem<Transform, RigidBody, SphereCollider>	_ColliderSystem(1);
	ECSSystem<AI>									_AISystem(1);
	ECSSystem<Transform, GraphicsComponent>			_RenderSystem(1);
	//System<Transform, RigidBody> _AISystem(1);
	//System<Transform> _GraphicsSystem(1);
}

#endif // SYSTEMS