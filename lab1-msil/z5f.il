
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.module extern ProgA.netmodule
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
.assembly extern jpdotnet.zad1msil.Normal
{
  .ver 0:0:0:0
}
.assembly jp.z5f
{
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.file ClassA.netmodule
    .hash = (08 A9 1A AB B6 ED D0 DE E4 17 6B 23 A4 8B DB 09   // ..........k#....
             B2 DD 2E EC )                                     // ....
.file ClassB.netmodule
    .hash = (66 D6 5F A4 6C 4C 12 05 81 0C 0B B5 58 61 22 3A   // f._.lL......Xa":
             6C E4 6E CF )                                     // l.n.
.file ProgA.netmodule
    .hash = (71 1A 8C 42 32 25 00 D1 74 2A 2D 26 EB 17 7B E2   // q..B2%..t*-&..{.
             52 9A 6F F0 )                                     // R.o.
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
.module jp.z5f.exe
// MVID: {4F24CD01-5B4A-48AF-A788-73D1B803A613}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x06E20000


// ================== GLOBAL METHODS =========================

.method privatescope static void  __EntryPoint$PST06000001() cil managed
{
  .entrypoint
  // Code size       8 (0x8)
  .maxstack  8
  IL_0000:  tail.
  IL_0002:  call       void [.module ProgA.netmodule]JP_NET.Lab1.Program::Main()
  IL_0007:  ret
} // end of global method __EntryPoint


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file z5f.res
