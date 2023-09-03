#ifndef WINDOWS_WINDOW
#define WINDOWS_WINDOW

//reduce code from windows.h 
#ifndef NOMINMAX
#define NOMINMAX
#endif//NOMINMAX
#ifndef WIN32_LEAN_AND_MEAN
#define WIN32_LEAN_AND_MEAN
#endif//WIN32_LEAN_AND_MEAN
#ifndef NOCOMM
#define NOCOMM
#endif//NOCOMM

#include <windows.h>

#include <string>


namespace TDS
{
	class WindowsWin
	{
	public:		//functions
				WindowsWin(HINSTANCE hInstance, int nCmdShow, const wchar_t* className);
				~WindowsWin();

     uint32_t	getWidth()  const noexcept;
	 uint32_t	getHeight() const noexcept;

	 void		setWidth(const uint32_t& _value) { m_Width = _value; }
	 void		setHeight(const uint32_t& _value) { m_Height = _value; }
	 

	 bool		registerWindow(const WNDPROC& wndproc);
	 bool		createWindow(const WNDPROC& wndproc);
	 bool		processInputEvent();
	
	 HWND		getWindowHandler() const { return m_handleWindows; }
	 HINSTANCE	getHInstance()	   const { return m_hInstance;     }
	private:	//functions

	public:		//variables

		struct Settings //will set to private in the future for now no optimization
		{
			bool validation		{ true };
			bool fullscreen		{ false };
			bool vsync			{ false };
			bool overlay		{ true	};
		
		}settings;

	private:	//variables

		int		  m_Width		  {};
		int		  m_Height		  {};
		HWND	  m_handleWindows {};
		HINSTANCE m_hInstance	  {};
		int		  m_cmdshow		  {};

		std::wstring_view  m_classname	{};


		static constexpr int minWidth {1280};
		static constexpr int minHeight {800};

	};

}//end TDS


#endif // !WINDOWS_WINDOW
