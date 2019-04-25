Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("ClassLibrary2")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("")> 
<Assembly: AssemblyProduct("ClassLibrary2")> 
<Assembly: AssemblyCopyright("Copyright ©  2012")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("3a34b4ab-c23c-4e35-92ee-00a53c75d47a")> 

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Build and Revision Numbers 
' by using the '*' as shown below:
' <Assembly: AssemblyVersion("1.0.*")> 

<Assembly: AssemblyVersion("1.0.0.0")> 
<Assembly: AssemblyFileVersion("1.0.0.0")> 


<Assembly: System.Diagnostics.DebuggerDisplay("MemoryUsage={{{Length / {Capacity,nq}}} ({(Length / Capacity).ToString(""p""),nq})",
    Target:=GetType(System.Text.StringBuilder))> 