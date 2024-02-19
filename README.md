# ProxyToggler
A Proxy toggling app that has a pinned dynamic taskbar icon!

https://github.com/mastercodeon314/ProxyToggler/assets/78676320/6227cf91-82b2-4374-8934-f8b87ee8ba87

This project started as an idea i had, what if we could pin an app icon to the taskbar, and when clicked on, would perform a function and then change the icon based on the function that was performed?
Well thats how ProxyToggler came to life. 
It simply toggles the system proxy for windows on or off, then it changes an icon (red circle for proxy off, green circle for proxy on) based on the proxy's new state.
Then the pttb.exe program thats embedded is used to pin and unpin the icon from the taskbar, thus changing the icon from red to green, or vice versa. 
I used the amazing release by 0x546F6D for the pinning and unpinning functionality for the taskbar.

## Build Process
+ Simply clone and build this project
+ Use resource hacker to add both the included icons in the project's directory.
+ Run the exe and ProxyToggler will install the shortcut to "%appdata%\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\"

## Notes
+ Running the program from Doccuments, or Downloads seems to break the icon thats assigned to the shortcut. Please do not run this from either location.

## References
- https://github.com/0x546F6D/pttb_-_Pin_To_TaskBar
- https://www.angusj.com/resourcehacker/
