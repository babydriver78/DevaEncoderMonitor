Notes on .Net Sample Applications

When building with later versions of Visual Studio than VS2005 and targeting a version of the .Net framework later than 2.0 it is necessary to add a line
of the following format to the projects app.config file, in the configuration section, in order to suppress a warning that the enclibnet.lib
assembly was built for an earlier version of the .net framework. this functionality may be needed to be added to your application project depending on the
.net version that your application targets.
 

e.g. For VS2010 .net 4.0

  <startup useLegacyV2RuntimeActivationPolicy="true">
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0"/>
  </startup>

later tools may require a different .Net version to be specified depending on the .net version being specified as the target version for the application.

The sample applications use prebuild events to copy the correct format enclibnet.dll binary, into the project output directory to support debugging 
as the reference to enclibnet.dll.

In Visual Studio 2012 and later the C++/CLI .net sample may fail to find the references to enclibnet.dll after being upgraded if this happens then 
simply remove the reference and re-add them setting the copy local property to false.

When building the samples for the first time, the prebuild step may fail, because the output directories do not exist, simply build all of the output types,
to ensure the directories are created and then the builds should succeed.
