#ifndef SERIALIZATION
#define SERIALIZATION

#include <rapidJSON/rapidjson.h>
#include <rapidJSON/document.h>
#include <rapidJSON/stringbuffer.h>
#include <rapidJSON/prettywriter.h>

namespace TDS
{
	class Serializer
	{
	public:
		/*!*************************************************************************
		Funtion for Deserializing to JSON file
		****************************************************************************/
		bool DeserializeFromFile(const std::string& filePath);
		/*!*************************************************************************
		Funtion for Serializing to JSON file
		****************************************************************************/
		bool SerializeToFile(const std::string& filePath);

		/*!*************************************************************************
		Json Serializer for calling Derived class Serialize function
		****************************************************************************/
		virtual std::string Serialize() const;
		/*!*************************************************************************
		Json Deserializer for calling Derived class Deserialize function
		****************************************************************************/
		virtual bool Deserialize(const std::string& stringbuffer);

		/*!*************************************************************************
		Virtual deserialize function for derived classes to overload
		****************************************************************************/
		virtual bool Deserialize(const rapidjson::Value& obj) = 0;
		/*!*************************************************************************
		Virtual serialize function for derived classes to overload
		****************************************************************************/
		virtual bool Serialize(rapidjson::PrettyWriter<rapidjson::StringBuffer>* writer) const = 0;

		virtual ~Serializer() = default;

	protected:
		/*!*************************************************************************
		Checks if Document can be Read
		****************************************************************************/
		bool InitDocument(const std::string& stringbuffer, rapidjson::Document& doc);
	};
}

#endif