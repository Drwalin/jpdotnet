
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.module extern ClassA.netmodule
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
.assembly jp.z1_5c
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.file ClassA.netmodule
    .hash = (08 A9 1A AB B6 ED D0 DE E4 17 6B 23 A4 8B DB 09   // ..........k#....
             B2 DD 2E EC )                                     // ....
.file ClassB.netmodule
    .hash = (66 D6 5F A4 6C 4C 12 05 81 0C 0B B5 58 61 22 3A   // f._.lL......Xa":
             6C E4 6E CF )                                     // l.n.
.class extern public JP_NET.Lab1.ClassA
{
  .file ClassA.netmodule
  .class 0x02000002
}
.class extern public JP_NET.Lab1.ClassB
{
  .file ClassB.netmodule
  .class 0x02000002
}
.module jp.z1_5c.exe
// MVID: {E1A49F82-852E-41F2-8935-F7207F161C1B}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x07380000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit JP_NET.Lab1.Program
       extends [mscorlib]System.Object
{
  .method public hidebysig static void  Main() cil managed
  {
    .entrypoint
    // Code size       30 (0x1e)
    .maxstack  2
    .locals init (class [.module ClassA.netmodule]JP_NET.Lab1.ClassA V_0)
    IL_0000:  nop
    IL_0001:  newobj     instance void [.module ClassA.netmodule]JP_NET.Lab1.ClassA::.ctor()
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  callvirt   instance void [.module ClassA.netmodule]JP_NET.Lab1.ClassA::MethodOfClassA()
    IL_000d:  nop
    IL_000e:  ldloc.0
    IL_000f:  ldc.i4.1
    IL_0010:  callvirt   instance void [.module ClassA.netmodule]JP_NET.Lab1.ClassA::set_A(int32)
    IL_0015:  nop
    IL_0016:  ldloc.0
    IL_0017:  ldc.i4.2
    IL_0018:  stfld      int32 [.module ClassA.netmodule]JP_NET.Lab1.ClassA::b
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
// WARNING: Created Win32 resource file z1_5c.res
