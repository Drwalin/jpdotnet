
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern System
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly JPNET.Lab1.O
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 02 00 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module JPNET.Lab1.O.dll
// MVID: {14AE23BD-5528-4495-B7A2-D8FBA1E38365}
.imagebase 0x10000000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x07220000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi beforefieldinit JP_NET.Lab1.ClassA
       extends [mscorlib]System.Object
{
  .field private int32 _a
  .field public int32 b
  .method public hidebysig specialname instance int32 
          get_A() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int32 JP_NET.Lab1.ClassA::_a
    IL_0006:  ret
  } // end of method ClassA::get_A

  .method public hidebysig specialname instance void 
          set_A(int32 'value') cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      int32 JP_NET.Lab1.ClassA::_a
    IL_0007:  ret
  } // end of method ClassA::set_A

  .method public hidebysig instance void 
          MethodOfClassA() cil managed
  {
    // Code size       50 (0x32)
    .maxstack  3
    .locals init (class [System]System.Diagnostics.FileVersionInfo V_0)
    IL_0000:  call       class [mscorlib]System.Reflection.Assembly [mscorlib]System.Reflection.Assembly::GetExecutingAssembly()
    IL_0005:  callvirt   instance string [mscorlib]System.Reflection.Assembly::get_Location()
    IL_000a:  call       class [System]System.Diagnostics.FileVersionInfo [System]System.Diagnostics.FileVersionInfo::GetVersionInfo(string)
    IL_000f:  stloc.0
    IL_0010:  ldstr      "{0}.{1}"
    IL_0015:  ldloc.0
    IL_0016:  callvirt   instance int32 [System]System.Diagnostics.FileVersionInfo::get_ProductMajorPart()
    IL_001b:  box        [mscorlib]System.Int32
    IL_0020:  ldloc.0
    IL_0021:  callvirt   instance int32 [System]System.Diagnostics.FileVersionInfo::get_ProductMinorPart()
    IL_0026:  box        [mscorlib]System.Int32
    IL_002b:  call       string [mscorlib]System.String::Format(string,
                                                                object,
                                                                object)
    IL_0030:  pop
    IL_0031:  ret
  } // end of method ClassA::MethodOfClassA

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method ClassA::.ctor

  .property instance int32 A()
  {
    .get instance int32 JP_NET.Lab1.ClassA::get_A()
    .set instance void JP_NET.Lab1.ClassA::set_A(int32)
  } // end of property ClassA::A
} // end of class JP_NET.Lab1.ClassA


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file O.2.res
