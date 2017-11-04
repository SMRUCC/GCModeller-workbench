# Web Browser Control & Specifying the IE Version

> https://weblog.west-wind.com/posts/2011/May/21/Web-Browser-Control-Specifying-the-IE-Version

I use the Internet Explorer Web Browser Control in a lot of my desktop applications to display document content. For example Markdown Monster, Help Builder and WebSurge rely heavily on the Web Browser Control to render their document centric or even rich interactive UI (in the case of Markdown Monster which hosts an HTML editor). Whether you're just rendering document content, or you're interacting with rich interactive content, HTML happens to be one of the most common document formats to display or interact with and it makes a wonderful addition to conventional forms based UI. Even in desktop applications, is often way easier than using labels or edit boxes or even some of the WPF text containers. HTML is easy to generate, generally re-usable, and easily extensible and distributable. The Web Browser Control allows for an effective way to display HTML in your applications in a way that blends in and becomes part of your application.

But there's a snag: The Web Browser Control is - by default - perpetually stuck in IE 7 rendering mode. Even though we're now up to IE 11 and a reasonably HTML5 compatible browser, the Web Browser Control always uses the IE 7 rendering engine by default. This is because the original versions of the ActiveX control used this mode and for backwards compatibility the Control continues this outdated and very HTML5 unfriendly default.

This applies whether you’re using the Web Browser control in a WPF application, a WinForms app, or FoxPro application using the ActiveX control. Behind the scenes all these UI platforms use the same COM interfaces and so you’re stuck with those same rules.

The good news is there are a couple of ways to override the default rendering behavior:

Using the IE X-UA-Compatible Meta header
Using Application specific FEATURE_BROWSER_EMULATION Registry Keys
But first lets see the problem more graphically.

Rendering Challenged
To see what I’m talking about, here are two screen shots rendering an HTML5 page that includes some CSS3 functionality – rounded corners and border shadows - from an earlier post. One uses Internet Explorer as a standalone browser, and one uses a simple WPF form that includes the Web Browser control.

Full IE Browser:

![](./IE9Browser_thumb.png)
> Full Web Browser Rendering  

Web Browser Control in a WPF form:

![](./WebBrowserControlWpfForm_2.png)
> WebBrowserControlWpfForm

The the full Internet Explorer the page displays the HTML correctly – you see the rounded corners and shadow displayed. Obviously the latter rendering using the Web Browser control in a WPF application is a bit lacking. Not only are the new CSS features missing but the page also renders in Internet Explorer’s quirks mode so all the margins, padding etc. behave differently by default, even though there’s a CSS reset applied on this page. But the default IE 7 mode doesn't recognize many of these settings resulting in a terrible render mode.

If you’re building an application that intends to use the Web Browser control for a live preview of some HTML this is clearly undesirable.

Using the X-UA-Compatible HTML Meta Tag
If you control the content in your Web Browser control by rendering the HTML pages you display yourself, the easiest way to provide later versions of the IE rendering engine is by using the IE Edge mode header. By adding a meta tag to the head of the HTML document rendered in the Web Browser Control you can effectively override the IE Rendering engine and specify which version of IE (or the latest version) to use.

The tag to use in the header looks like this:

```html
<meta http-equiv="X-UA-Compatible" content="IE=edge" /> 
```

Inside of a full document it looks like this:

```html
<!DOCTYPE html> 
<html> 
  <head> 
    <meta http-equiv="X-UA-Compatible" content="IE=edge" /> 
    ... other headers
  </head>
  <body>
    ... content
  </body>
</html>
```

Note the header should be the first header so that the engine is applied before any other headers are processed.

In this case IE=edge uses the current version of IE that is installed on the machine. So if you have IE 11 installed that's used, if IE 10 is installed that's used.

You can also specify a specific version of IE:

```html
<meta http-equiv="X-UA-Compatible" content="IE=10" /> 
```

For info on all the modes available see this StackOverflow answer.

Alternately you can also serve X-UA-Compatible: IE=edge as a raw HTTP header from a Web server, which has the same behavior as the http-equiv meta header.

Caveats with the Edge Mode Header
There are a few things you need in order to use the meta tag and make it work properly:

You have to control the Page
In order to add the ``<meta>`` tag you have to control the page so that you can add the ``<meta>`` tag into your HTML. If you're rendering arbitrary HTML that doesn't include the tag, then this approach won't work obviously. Typically the header approach works great if you generate your own content.

Browser Version Reporting is incorrect
The ``<meta>`` tag changes the rendering engine behavior that IE uses, but it doesn't change the way that IE reports its version. If you access pages that do IE version checking you'll find that it still points at IE 7 (or sometime some custom browser version) that doesn't reflect the current rendering mode. If you're running script code that may rely on browser sniffing this can become a problem. I ran into this recently with Ace Editor, which has a couple of odd places where it uses browser sniffing for dealing with the clipboard, and that code wouldn't work. This is likely an edge (ha ha) case, but be aware that this can become a problem.

Feature Delegation via Registry Hacks
Another and perhaps more robust way to affect the Web Browser Control version is by using FEATURE_BROWSER_EMULATION. Starting with IE 8 Microsoft introduced registry entries that control browser behavior when a Web Browser Control is embedded into other applications. These registry values are used by many application on your system.

Essentially you can specify a registry with the name of your Executable and specify the version of IE that you would like to load. The numbers are specified as 11000, 10000, 9000, 8000 and 7000. The keys can be specified either for the current user (HKCU) or globally for all users (HKLM).

Here's what I have in my HKCU key:

![](./registrySettings.png)
> Registry Settings in HKCU

Notice some big applications like Visual Studio and Outlook use these overrides and at the HKLM keys you will also find apps like Skype SnagIt, Fiddler, SourceTree, 1Password and the Windows Help Viewer to name a few. So this feature is actually used by a wide range of popular software.

Registry Key Location for FEATURE_BROWSER EMULATION
You can specify these keys in the registry at:

``HKEY_CURRENT_USER\SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION``
The HKCU key is the best place to set these values because there's a single key and it can be set without admin rights, but you can also set these keys at the machine level at HKLM:

``HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION``
or for a 32 bit application on a 64 bit machine:

``HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION``
Key Name
The keyname is the EXE name of your application like:

outlook.exe
MarkdownMonster.exe
Values
The value specifies the IE version as follows:

The value to set this key to is (taken from MSDN here) as decimal values:

11001 (0x2AF9)
Internet Explorer 11. Webpages are displayed in IE11 Standards mode, regardless of the !DOCTYPE directive.

11000 (0x2AF8)
Internet Explorer 11. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode.

10001 (0x2AF7)
Internet Explorer 10. Webpages are displayed in IE10 Standards mode, regardless of the !DOCTYPE directive.

10000 (0x2710)
Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode.

9999 (0x270F)
Internet Explorer 9. Webpages are displayed in IE9 Standards mode, regardless of the !DOCTYPE directive.

9000 (0x2328)
Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode.

8888 (0x22B8)
Webpages are displayed in IE8 Standards mode, regardless of the !DOCTYPE directive.

8000 (0x1F40)
Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode.

7000 (0x1B58)
Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. This mode is kind of pointless since it's the default.

Setting these keys enables your applications to use the latest Internet Explorer versions on your machine easily. Unfortunately there doesn't seem to be a key that says use the latest version that's installed - you have to be specific regarding the version unfortunately. Given that Windows 7 and later can run IE 11, I'm requiring users to have IE 11 if I want to use HTML5 and more advanced CSS features like Flexbox, but if your content is simpler you can probably get away with using IE 10 or even IE 9.

Don’t forget to add Keys for Host Environments
As mentioned above you have to specify the name of the EXE you're running as the key in the registry.

If you're using a development environment like Visual Studio or Visual FoxPro to debug your applications, keep in mind that your main EXE you are running while debugging may not be the final EXE that you are building. So after you've set up your registry keys, your debugging experience may still not see the enhanced rendering features in the Web Browser control because you're not actually running the final EXE.

The problem is that when you debug in these environments, you are running a debugging host and in order for it to render properly you may have to the host to the FEATURE_BROWSER_EMULATION keys as well.

For Visual Studio this will be yourapp.vshost.exe, which is the debugging host. For Visual FoxPro you'll want vfp9.exe. Simply add these keys to the registry alongside those you use for your actual, live application.

Registry Key Installation for your Application
It’s important to remember that the registry settings from above are made per application, so most likely this is something you want to set up with your installer. I let my installers write the values into the registry during the install process which also removes the keys on uninstall.

Personally I always prefer setting this value per user using using the HKCU key which works for both 32 and 64 bit applications in one place.

If you set the keys globally on HKLM for all users, remember that 32 and 64 bit settings require separate settings in the registry. So if you’re creating your installer you most likely will want to set both keys in the registry preemptively for your application.

Installation
As an example, I use InnoSetup for just about all of my installs now which looks like this:

; IE 11 mode
Root: HKCU; Subkey: "Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION"; ValueType: dword; ValueName: "MarkdownMonster.exe"; ValueData: "11001"; Flags: createvalueifdoesntexist
Other installer products will also let you install keys directly.

Note that if you use the HKEY_LOCAL_MACHINE key you can also add the registry keys directly as part of your application when it starts up.

The following is .NET code, but it should give you an idea how to easily create the keys:

```
public static void EnsureBrowserEmulationEnabled(string exename = "MarkdownMonster.exe", bool uninstall = false)
{

    try
    {
        using (
            var rk = Registry.CurrentUser.OpenSubKey(
                    @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true)
        )
        {
            if (!uninstall)
            {
                dynamic value = rk.GetValue(exename);
                if (value == null)
                    rk.SetValue(exename, (uint)11001, RegistryValueKind.DWord);
            }
            else
                rk.DeleteValue(exename);
        }
    }
    catch
    {
    }
}
```

Summary

It would be nice if the Web Browser Control would just use the native Internet Explorer engine as is, but as you see in this article, that's unfortunately not the case and you have to coerce the browser. If you have control over your documents that you render in the Web Browser Control you may be able to use X-UA-Compatible header in your pages. Otherwise you have to resort to the registry hack using FEATURE_BROWSER_EMULATION.

Personally I've used the registry hack for all of my apps that use the Web Browser Control because my applications tend to render HTML from all sorts of different sources - local generated content, as well as Web loaded pages for previews and sometimes even dynamically injected content. It's better to force the latest IE version for all content than forget the fact you need custom headers for other non-application content you might display (update notices, registration forms, notifications etc.)

These days most machines will be running either IE 10 or 11, so there's much less of a problem with differening browser behavior than there used to be.