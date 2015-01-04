using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("FxCopWrapper")]
[assembly: AssemblyDescription("Modify default FxCop rules.")]
[assembly: AssemblyProduct("FxCopWrapper")]
[assembly: AssemblyCopyright("Copyright ©  2015 Brad Hess")]
[assembly: AssemblyCompany("Brad Hess")]
[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]
[assembly: Guid("e03b14bf-6fcd-45b2-a43e-a490e1c828de")]
[assembly: SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames",
    Justification = "This is a development-time dependency.")]
