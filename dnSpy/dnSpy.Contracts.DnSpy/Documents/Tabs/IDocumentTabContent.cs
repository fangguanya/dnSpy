﻿/*
    Copyright (C) 2014-2016 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using dnSpy.Contracts.Documents.TreeView;

namespace dnSpy.Contracts.Documents.Tabs {
	/// <summary>
	/// Contains the data used to generate the content shown in a tab
	/// </summary>
	public interface IDocumentTabContent {
		/// <summary>
		/// Gets all nodes used to generate the content
		/// </summary>
		IEnumerable<IDocumentTreeNodeData> Nodes { get; }

		/// <summary>
		/// Called to show its content in the UI. Implement <see cref="IAsyncDocumentTabContent"/> to
		/// create the content in a worker thread.
		/// </summary>
		/// <param name="ctx">UI Context created by <see cref="CreateUIContext(IDocumentTabUIContextLocator)"/></param>
		/// <returns></returns>
		void OnShow(IShowContext ctx);

		/// <summary>
		/// Called when the content is hidden
		/// </summary>
		void OnHide();

		/// <summary>
		/// Called when its tab has been selected. Only called if this is the tab's active content.
		/// </summary>
		void OnSelected();

		/// <summary>
		/// Called when its tab has been unselected. Only called if this is the tab's active content.
		/// </summary>
		void OnUnselected();

		/// <summary>
		/// Gets the title
		/// </summary>
		string Title { get; }

		/// <summary>
		/// Gets the tooltip
		/// </summary>
		object ToolTip { get; }

		/// <summary>
		/// true if <see cref="Clone"/> can be called
		/// </summary>
		bool CanClone { get; }

		/// <summary>
		/// Clones this instance. Can only be called if <see cref="CanClone"/> is true
		/// </summary>
		/// <returns></returns>
		IDocumentTabContent Clone();

		/// <summary>
		/// Creates the <see cref="IDocumentTabUIContext"/> instance needed by this instance. This
		/// instance will only be used in this tab.
		/// </summary>
		/// <param name="locator">Can be used to get a per-tab shared instance</param>
		/// <returns></returns>
		IDocumentTabUIContext CreateUIContext(IDocumentTabUIContextLocator locator);

		/// <summary>
		/// Written by the owner <see cref="IDocumentTab"/> instance
		/// </summary>
		IDocumentTab DocumentTab { get; set; }
	}
}
