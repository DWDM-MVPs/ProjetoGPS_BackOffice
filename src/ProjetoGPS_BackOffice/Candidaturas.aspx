<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Candidaturas.aspx.cs" Inherits="ProjetoGPS_BackOffice._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

		<div class="w3-bar w3-black">
  <button class="w3-bar-item w3-button" onclick="openCity('London')">London</button>
  <button class="w3-bar-item w3-button" onclick="openCity('Paris')">Paris</button>
  <button class="w3-bar-item w3-button" onclick="openCity('Tokyo')">Tokyo</button>
</div>


	<div id="London" class="city">
  <h2>London</h2>
  <p>London is the capital of England.</p>
</div>

<div id="Paris" class="city" style="display:none">
  <h2>Paris</h2>
  <p>Paris is the capital of France.</p>
</div>

<div id="Tokyo" class="city" style="display:none">
  <h2>Tokyo</h2>
  <p>Tokyo is the capital of Japan.</p>
</div>


<script>
		  function openCity(cityName) {
			  var i;
			  var x = document.getElementsByClassName("city");
			  for (i = 0; i < x.length; i++) {
				  x[i].style.display = "none";
			  }
			  document.getElementById(cityName).style.display = "block";
		  }
</script>


	<div class="jumbotron">
		<h1>Candidaturas</h1>
	</div>

	



	<% foreach (Applications ap in Aps)
		{

	%>




	<div class="jumbotron">
		<h2><%=ap.Name%> <%=ap.Surname%></h2>
		<h4><%=ap.Email%></h4>
		<h4><%=ap.City%></h4>
		<p></p>
		<p><%=ap.Message%></p>
		<p>
			<button type="button" class="btn btn-success">Aceitar</button>
			<button type="button" class="btn btn-danger">Rejeitar</button>
		</p>
	</div>
	<%} %>
</asp:Content>
