// dllmain.cpp : Определяет точку входа для приложения DLL.
#include "pch.h"






bool ___setpos(HWND hWnd , HWND hWndInsertAfter , UINT uFlags) {
    return SetWindowPos(hWnd, hWndInsertAfter, 0, 0, 0, 0, uFlags);
}

extern "C" __declspec(dllexport) bool _SetWinPosition(HWND hWnd, HWND hWndInsertAfter, UINT uFlags)
{
    return ___setpos(hWnd, hWndInsertAfter, uFlags);
}

extern "C" __declspec(dllexport) bool _SetWindowPosG(HWND hWnd)
{
    return ___setpos(hWnd , HWND_TOPMOST, SWP_NOMOVE | SWP_NOREPOSITION | SWP_NOSIZE);
}
 





extern "C" __declspec(dllexport) void _MakeTransparent(HWND hWnd)
{
    long long__ = GetWindowLong(hWnd, -20);
    SetWindowLong(hWnd, -20, long__ | 0x20);
}
extern "C" __declspec(dllexport) void _MakeNormal(HWND hWnd)
{
    long long__ = GetWindowLong(hWnd, -20);
    SetWindowLong(hWnd, -20, long__ | -33);
}

extern "C" __declspec(dllexport) void _HideWin_Tab(HWND hWnd)
{
    long long__ = GetWindowLong(hWnd, -20);
    long__ |= 0x00000080;
    SetWindowLong(hWnd, -20,  long__);
}












BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

