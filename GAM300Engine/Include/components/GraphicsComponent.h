#pragma once
#include "ecs/ecs.h"
#include "ResourceManagement/ResourceManager.h"
namespace TDS
{
	class AssetModel;
	class Texture;

	class GraphicsComponent : public IComponent
	{
	public:
		DLL_API GraphicsComponent();
		DLL_API GraphicsComponent(GraphicsComponent&& toMove) noexcept;
		DLL_API ~GraphicsComponent() = default;

		inline void								ToggleRender(bool condition) { m_ShowMesh = condition; }
		inline void								TogglePointLight(bool status) { m_Pointlight = status; }
		inline void								SetPointLightID(int ID) { m_PointLightID = ID; }
		inline void								SetColor(Vec4 Color) { m_Color = Color; }
		inline void								SetColor(float r, float g, float b, float a) { m_Color = { r,g,b,a }; }
		inline void								SetTextureName(std::string input) { m_TextureName = input; }
		inline void								ToggleDebug(bool status) { m_Debug = status; }
		inline void								SetView2D(bool status) { m_UsedIn2D = status; }
		
		inline bool								ShowMesh() { return m_ShowMesh; }
		inline bool								View2D() { return m_UsedIn2D; }
		inline TypeReference<AssetModel>& 		GetAsset() { return m_AssetReference; }
		inline TypeReference<Texture>&			GetTexture() { return m_TextureReference; }
		inline bool&							IsPointLight() { return m_Pointlight; }
		inline int&								GetPointLightID() { return m_PointLightID; }
		inline Vec4&							GetColor() { return m_Color; }
		inline std::string&						GetTextureName() { return m_TextureName; }
		inline bool&							IsDebugOn() { return m_Debug; }
		inline void								SetModelName(std::string input) { m_ModelName = input; }
		inline std::string&						GetModelName() { return m_ModelName; }


		RTTR_ENABLE(IComponent);
		RTTR_REGISTRATION_FRIEND

	private:
		bool							m_ShowMesh = true;
		Vec4							m_Color;
		int								m_PointLightID{ -1 };
		bool							m_Pointlight{ false };
		bool							m_Debug{ false };
	public:
		TypeReference<AssetModel> 		m_AssetReference;
		TypeReference<Texture>			m_TextureReference;
		std::string						m_ModelName = "";
		std::string						m_TextureName = "";
		bool							m_UsedIn2D{ false };


	};
}