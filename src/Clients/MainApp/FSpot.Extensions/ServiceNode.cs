//
// ServiceNode.cs
//
// Author:
//   Stephane Delcroix <sdelcroix@src.gnome.org>
//
// Copyright (C) 2008 Novell, Inc.
// Copyright (C) 2008 Stephane Delcroix
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED AS IS, WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;

using Mono.Addins;

namespace FSpot.Extensions
{
	public class ServiceNode : ExtensionNode
	{
		[NodeAttribute ("class", true)]
		protected string class_name;

		IService service = null;

		public void Initialize ()
		{
			service = Addin.CreateInstance (class_name) as IService;
		}

		public bool Start ()
		{
			if (service == null)
				throw new Exception ("Service not initialized. Call Initialize () prior to Start() or Stop()");
			return service.Start ();
		}

		public bool Stop ()
		{
			if (service == null)
				throw new Exception ("Service not initialized. Call Initialize () prior to Start() or Stop()");
			return service.Stop ();
		}
	}
}
