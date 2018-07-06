# Skia Talk Outline

## A little about Works24

* Digital Signage, On Hold Messaging, Overhead music
* Hodgepodge of systems written over 16 years, VB6 COM/SQL Server, Classic ASP, .NET Webforms, MVC 2
* Paying off technical debt and modernizing, cutting server and software costs
* New platform: .NET Core 2 WebApi running on Docker in Debian Linux, Angular Front-End
* Big hurdle: We draw lots and lots of images in .NET using System.Drawing

## System.Drawing

* Wrapper around GDI+, 2D graphics library introduced with Windows XP
* Deeply tied to Windows - Not cross-platform
* Limited functionality in .NET Core (CoreCompat/System.Drawing), full functionality on Windows hosts (referencing full framework)

## Options

### Written in .NET

* ImageSharp (github.com/SixLabors/ImageSharp): Written in C#, cross platform, thread safe.
* ImageResizer (Windows-only, but their cross-platform version, ImageFlow, is in alpha)
* Several smaller projects, search "Image Resizing" in NuGet
* If you just need to resize or watermark images, go with one of these.

### Native with Wrapper

* Magick.NET: Windows support complete, Linux/Mac WIP
* FreeImage-dotnet-core: rough around the edges
* SkiaSharp

### Skia/SkiaSharp

* Drawing engine for Chrome, Android and Firefox
* Created/Backed by Google
* BSD License
* Microsoft just took over the SkiaSharp .NET Core Wrapper library (originally created by Xamarin)
* Feature parity with System.Drawing

### Let's look at some code!

### Q&A




## References

* https://blogs.msdn.microsoft.com/dotnet/2017/01/19/net-core-image-processing/
* https://github.com/matgr1/FreeImage-dotnet-core
* https://sixlabors.github.io/docs/articles/ImageSharp/GettingStarted.html
* https://skia.org/


