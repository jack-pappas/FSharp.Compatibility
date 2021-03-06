﻿(*

Copyright 2005-2009 Microsoft Corporation
Copyright 2012 Jack Pappas

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

*)

module internal AssemblyInfo

open System
open System.Diagnostics.CodeAnalysis
open System.Reflection
open System.Runtime.CompilerServices
open System.Runtime.InteropServices
open System.Security.Permissions


(* Assembly information *)
[<assembly: Guid("6969A4AC-E2AA-4D30-9426-32A994B5F8E3")>]
// TODO : Make sure the assembly is actually CLS-compliant, then enable this attribute.
//[<assembly: CLSCompliant(true)>]

(* Security *)
#if FX_NO_SECURITY_PERMISSIONS
#else
#if FX_SIMPLE_SECURITY_PERMISSIONS
[<assembly: SecurityPermission(SecurityAction.RequestMinimum)>]
#else
#endif
#endif

(* NGen dependencies *)
#if FX_NO_DEFAULT_DEPENDENCY_TYPE
#else
[<assembly: Dependency("FSharp.Core", LoadHint.Always)>]
// TODO : Add DefaultDependency attribute
#endif

(* Automatically open base namespaces and modules *)
//[<assembly: AutoOpen("FSharp.Compatibility.OCaml")>]

(* Suppress some FxCop messages *)
[<assembly: SuppressMessage(
    "Microsoft.Globalization",
    "CA1305:SpecifyIFormatProvider",
    Scope = "member",
    Target = "Internal.Utilities.Pervasives+OutChannelImpl.#.ctor(Internal.Utilities.Pervasives+writer)",
    MessageId = "System.IO.TextWriter.#ctor")>]

// This is needed because F# doesn't recognize assembly-level attributes as module
// content; without this, the module appears empty and the compiler gives an error.
do ()
