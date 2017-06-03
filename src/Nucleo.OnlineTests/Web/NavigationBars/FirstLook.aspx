<%@ Page Title="" Language="C#" MasterPageFile="~/Web/test.master" AutoEventWireup="true" CodeBehind="FirstLook.aspx.cs" Inherits="Nucleo.Web.ContentControls.NavigationBars.FirstLook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CodeSample" runat="server">

	<n:NavigationBarContainer ID="navContainer" runat="server" Width="500px">
		<Bars>
			<n:NavigationBar ID="navBar1" runat="server">
				<Items>
					<n:NavigationBarItem ID="navBarItem1" runat="server" Text="First Item" />
					<n:NavigationBarItem ID="navBarItem2" runat="server" Text="Second Item" />
					<n:NavigationBarItem ID="navBarItem3" runat="server" Text="Third Item" />
					<n:NavigationBarItem ID="navBarItem4" runat="server" Text="Fourth Item" />
				</Items>
			</n:NavigationBar>
			<n:NavigationBar ID="navBar2" runat="server">
				<Items>
					<n:NavigationBarItem ID="NavigationBarItem1" runat="server">
						<Content>
							<Template>
								<asp:Image runat="server" ImageUrl="~/TestImages/onebit_05.png" />
							</Template>							
						</Content>
					</n:NavigationBarItem>
					<n:NavigationBarItem ID="NavigationBarItem2" runat="server">
						<Content>
							<Template>
								<asp:Image runat="server" ImageUrl="~/TestImages/onebit_06.png" />
							</Template>
						</Content>
					</n:NavigationBarItem>
					<n:NavigationBarItem ID="NavigationBarItem3" runat="server">
						<Content>
							<Template>
								<asp:Image runat="server" ImageUrl="~/TestImages/onebit_07.png" />
							</Template>
						</Content>
					</n:NavigationBarItem>
					<n:NavigationBarItem ID="NavigationBarItem4" runat="server">
						<Content>
							<Template>
								<asp:Image runat="server" ImageUrl="~/TestImages/onebit_08.png" />
							</Template>
						</Content>
					</n:NavigationBarItem>
				</Items>
			</n:NavigationBar>
		</Bars>
	</n:NavigationBarContainer>

</asp:Content>