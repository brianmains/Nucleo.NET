<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Web.PageableList.FirstLook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

	<n:PageableList id="pagelist" runat="server" Orientation="Horizontal" VisibleItemCount="3">
		<PagingOptions LeftImageUrl="~/TestImages/onebit_20.png" 
			RightImageUrl="~/TestImages/onebit_21.png" />
		<Items>
			<n:PageableListItem ID="child1" runat="server">
				<Content>
					<Template>
						<asp:Image runat="server" ImageUrl="~/TestImages/onebit_01.png" />
					</Template>
				</Content>
			</n:PageableListItem>
			<n:PageableListItem ID="child2" runat="server">
				<Content>
					<Template>
						<asp:Image runat="server" ImageUrl="~/TestImages/onebit_02.png" />
					</Template>
				</Content>
			</n:PageableListItem>
			<n:PageableListItem ID="child3" runat="server">
				<Content>
					<Template>
						<asp:Image runat="server" ImageUrl="~/TestImages/onebit_03.png" />
					</Template>
				</Content>
			</n:PageableListItem>
			<n:PageableListItem ID="child4" runat="server">
				<Content>
					<Template>
						<asp:Image runat="server" ImageUrl="~/TestImages/onebit_04.png" />
					</Template>
				</Content>
			</n:PageableListItem>
			<n:PageableListItem ID="child5" runat="server">
				<Content>
					<Template>
						<asp:Image runat="server" ImageUrl="~/TestImages/onebit_05.png" />
					</Template>
				</Content>
			</n:PageableListItem>
			<n:PageableListItem ID="child6" runat="server">
				<Content>
					<Template>
						<asp:Image runat="server" ImageUrl="~/TestImages/onebit_06.png" />
					</Template>
				</Content>
			</n:PageableListItem>
			<n:PageableListItem ID="child7" runat="server">
				<Content>
					<Template>
						<asp:Image runat="server" ImageUrl="~/TestImages/onebit_07.png" />
					</Template>
				</Content>
			</n:PageableListItem>
			<n:PageableListItem ID="child8" runat="server">
				<Content>
					<Template>
						<asp:Image runat="server" ImageUrl="~/TestImages/onebit_08.png" />
					</Template>
				</Content>
			</n:PageableListItem>
			<n:PageableListItem ID="child9" runat="server">
				<Content>
					<Template>
						<asp:Image runat="server" ImageUrl="~/TestImages/onebit_09.png" />
					</Template>
				</Content>
			</n:PageableListItem>
			<n:PageableListItem ID="child10" runat="server">
				<Content>
					<Template>
						<asp:Image runat="server" ImageUrl="~/TestImages/onebit_10.png" />
					</Template>
				</Content>
			</n:PageableListItem>
		</Items>
	</n:PageableList>
	
	<n:PageableList id="PageableList1" runat="server" Orientation="Vertical" VisibleItemCount="3">
		<PagingOptions UpImageUrl="~/TestImages/onebit_20.png" 
			DownImageUrl="~/TestImages/onebit_21.png" />
		<Items>
			<n:PageableListItem ID="PageableListItem1" runat="server">
				<Content>
					<Template>
						<asp:Image ID="Image1" runat="server" ImageUrl="~/TestImages/onebit_01.png" />
					</Template>
				</Content>
			</n:PageableListItem>
			<n:PageableListItem ID="PageableListItem2" runat="server">
				<Content>
					<Template>
						<asp:Image ID="Image2" runat="server" ImageUrl="~/TestImages/onebit_02.png" />
					</Template>
				</Content>
			</n:PageableListItem>
			<n:PageableListItem ID="PageableListItem3" runat="server">
				<Content>
					<Template>
						<asp:Image ID="Image3" runat="server" ImageUrl="~/TestImages/onebit_03.png" />
					</Template>
				</Content>
			</n:PageableListItem>
			<n:PageableListItem ID="PageableListItem4" runat="server">
				<Content>
					<Template>
						<asp:Image ID="Image4" runat="server" ImageUrl="~/TestImages/onebit_04.png" />
					</Template>
				</Content>
			</n:PageableListItem>
			<n:PageableListItem ID="PageableListItem5" runat="server">
				<Content>
					<Template>
						<asp:Image ID="Image5" runat="server" ImageUrl="~/TestImages/onebit_05.png" />
					</Template>
				</Content>
			</n:PageableListItem>
			<n:PageableListItem ID="PageableListItem6" runat="server">
				<Content>
					<Template>
						<asp:Image ID="Image6" runat="server" ImageUrl="~/TestImages/onebit_06.png" />
					</Template>
				</Content>
			</n:PageableListItem>
			<n:PageableListItem ID="PageableListItem7" runat="server">
				<Content>
					<Template>
						<asp:Image ID="Image7" runat="server" ImageUrl="~/TestImages/onebit_07.png" />
					</Template>
				</Content>
			</n:PageableListItem>
			<n:PageableListItem ID="PageableListItem8" runat="server">
				<Content>
					<Template>
						<asp:Image ID="Image8" runat="server" ImageUrl="~/TestImages/onebit_08.png" />
					</Template>
				</Content>
			</n:PageableListItem>
			<n:PageableListItem ID="PageableListItem9" runat="server">
				<Content>
					<Template>
						<asp:Image ID="Image9" runat="server" ImageUrl="~/TestImages/onebit_09.png" />
					</Template>
				</Content>
			</n:PageableListItem>
			<n:PageableListItem ID="PageableListItem10" runat="server">
				<Content>
					<Template>
						<asp:Image ID="Image10" runat="server" ImageUrl="~/TestImages/onebit_10.png" />
					</Template>
				</Content>
			</n:PageableListItem>
		</Items>
	</n:PageableList>

</asp:Content>