
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern jpdotnet.zad1msil.Normal
{
  .ver 0:0:0:0
}
.assembly jpdotnet.zad1msil2.Normal
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module jpdotnet.zad1msil2.Normal.exe
// MVID: {42B2E871-FE89-4A00-90B9-D5305CE3163C}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x04EE0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit JP_NET.Lab1.Program
       extends [mscorlib]System.Object
{
  .method public hidebysig static void  Main() cil managed
  {
    .entrypoint
    // Code size       30 (0x1e)
    .maxstack  2
    .locals init (class [jpdotnet.zad1msil.Normal]JP_NET.Lab1.ClassA V_0)
    IL_0000:  nop
    IL_0001:  newobj     instance void [jpdotnet.zad1msil.Normal]JP_NET.Lab1.ClassA::.ctor()
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  callvirt   instance void [jpdotnet.zad1msil.Normal]JP_NET.Lab1.ClassA::MethodOfClassA()
    IL_000d:  nop
    IL_000e:  ldloc.0
    IL_000f:  ldc.i4.1
    IL_0010:  callvirt   instance void [jpdotnet.zad1msil.Normal]JP_NET.Lab1.ClassA::set_A(int32)
    IL_0015:  nop
    IL_0016:  ldloc.0
    IL_0017:  ldc.i4.2
    IL_0018:  stfld      int32 [jpdotnet.zad1msil.Normal]JP_NET.Lab1.ClassA::b
    IL_001d:  ret
  } // end of method Program::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Program::.ctor

} // end of class JP_NET.Lab1.Program


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file zad1msil2.Nromal.res
