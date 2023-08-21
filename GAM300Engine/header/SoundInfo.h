#pragma once

#include <string>
#include <array>
#include <time.h>

enum SOUND_STATE
{
    SOUND_ERR = 0,
    SOUND_LOADED,
    SOUND_UNLOAD,
};

struct SoundInfo {

    std::string uniqueID;

    const char* filePath;

    bool isitLoop, isit3D, isitLoaded;

    std::array<float, 3> posVec; //!!!!!!!To be replaced when vec container is used

    float volume, ReverbAmount;

    SOUND_STATE state;

    // convienience method to set the 3D coordinates of the sound.
    void set3DCoords(float x, float y, float z) {
        this->posVec[0] = x, this->posVec[1] = y, this->posVec[2] = z; //!!!!!!!To be replaced when vec container is used
    }

    bool isLoaded()
    {
        return isitLoaded;
    }

    bool is3D()
    {
        return isit3D;
    }

    bool isLoop()
    {
        return isitLoop;
    }

    std::string getUniqueID()
    {
        return uniqueID;
    }

    const char* getFilePath()
    {
        return filePath;
    }

    float getX()
    {
        return posVec[0]; //!!!!!!!To be replaced when vec container is used
    }

    float getY()
    {
        return posVec[1]; //!!!!!!!To be replaced when vec container is used
    }

    float getZ()
    {
        return posVec[2];
    }

    float getReverbAmount()
    {
        return ReverbAmount;
    }

    float getVolume()
    {
        return volume;
    }

    /**
    * Parameter takes in Volume values (0 - 100)
    */
    void setVolume(float vol)
    {
        volume = 20.0f * log10f(vol);
    }

    void setLoaded(SOUND_STATE setting)
    {
        state = setting;
    }

    SoundInfo(const char* _filePath = "", bool _isLoop = false, bool _is3D = false, bool _isLoaded = false, float _x = 0.0f, float _y = 0.0f, float _z = 0.0f, float _volume = 50.f, float _reverbamount = 0.f)
        : filePath(_filePath), isitLoop(_isLoop), isit3D(_is3D), isitLoaded(_isLoaded), posVec{_x, _y, _z}  //!!!!!!!To be replaced when vec container is used
    {
        uniqueID = filePath;
        state = SOUND_UNLOAD;
    }

    // TODO  implement sound instancing
    // int instanceID = -1; 

};