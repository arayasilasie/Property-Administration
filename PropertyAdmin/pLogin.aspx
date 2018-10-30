<%@ Page Title="Log In" Language="C#" MasterPageFile="~/mTop.Master" AutoEventWireup="true" CodeBehind="pLogin.aspx.cs" Inherits="ECXERP.pLogin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="JavaScript" type="text/javascript" >
        function Show() {
            document.getElementById("tdfirst").style.display = 'block';

        }
        function Hide() {

            document.getElementById("tdfirst").style.display = 'none';
        }
        function Show2() {
            document.getElementById("tdsecond").style.display = 'block';

        }
        function Hide2() {

            document.getElementById("tdsecond").style.display = 'none';
        }
        function Show3() {
            document.getElementById("tdthird").style.display = 'block';

        }
        function Hide3() {

            document.getElementById("tdthird").style.display = 'none';
        }
        function Show4() {
            document.getElementById("tdforth").style.display = 'block';

        }
        function Hide4() {

            document.getElementById("tdforth").style.display = 'none';
        }
        function Show5() {
            document.getElementById("tdfivth").style.display = 'block';

        }
        function Hide5() {

            document.getElementById("tdfivth").style.display = 'none';
        }
        function DivVisibleHide() {
            //$("#<=pnlOne.ClientID%>").mouseover(function () {
                document.getElementById("divAll").style.visibility = 'hidden';
               // document.getElementById("tdfirst").style.display = 'block';
           // }
        }
        function DivVisible() {

            document.getElementById("divAll").style.visibility = 'Visible';
        }
</script>
   <%-- <table width="100%">
          <tr>
            <td align="right">
              <asp:LinkButton ID="lbLogin" runat="server" CausesValidation="false" OnClick="lbLogin_Click">Log In</asp:LinkButton><br />
             </td>
          </tr>
        </table>--%>
    <asp:Label ID="lblStatus" runat="server" Text="" Width="100%" CssClass="statuslabel" Visible="false" ></asp:Label>

<div>
<asp:panel ID="pnlOne" runat="server"  >
  <table width="100%" border="1">
   <tr style="border-style: solid; border-width: thin; border-color: inherit;">
      <td align="center" colspan="2" style="border: thin solid #000000; text-align: center; width: 692px; background-color:#ACBA82;">
        <div>
          <table width="100%">
            <tr>
              <td align="center" style="background-color:#ACBA82">
                <asp:Label ID="lblPageTitle" runat="server" Text="Anonymous Exit Feedback" CssClass="pagetitle" ></asp:Label>
              </td>
              <td align="right">
               <asp:Label  id="inp" runat="server"  CssClass="pagetitle" Text="Click Here -->"></asp:Label>
               <u> <img alt="" onclick="Show()" src="Images/downArrow.jpg" style="height: 25px; margin-left: 0px; width: 22px;" /></u>
               <u> <img alt="" onclick="Hide()"  src="Images/upArrow.jpg"  style="height: 25px; width: 22px;" /></u>
              </td>
            </tr>
          </table>
        </div>
      </td>        
    </tr>
     <tr> 
      <td id="tdfirst" style="border: thin solid #000080; text-align: left;display:none;">     
     <div id="div1">  
          <table width="100%">
          <tr>
          <td colspan="3" style="background-color:	#CDD6B4;  color:#ec0974;  text-align:center;  border: 2px solid Green;  border-bottom:none 0px;">
          <asp:Label ID="lblIntro1" runat="server" Text="The purpose of this interview is to give you the opportunity to offer insightful feedback that the exchange kindly requests to increase employees performance and tenure. Thanking you for your efforts and contribution during your time with ECX, we trust that you will keep your relationship with us and promote the achievement of the Exchange mission in your future journey."></asp:Label>
            </td>
          </tr>
          <tr>
          <td colspan="3" abbr="center" style="background-color:	#CDD6B4;  color:#ec0974;  text-align:center;   border: 2px solid Green; border-top:none 0px; border-bottom:none 0px; font-weight:bolder;">
          <asp:Label ID="lblIntro2" runat="server" Text="Please note that all information collected will be kept anonymous."></asp:Label>
          </td>
          </tr>
          <tr>
          <td colspan="3" abbr="center" style="background-color:	#CDD6B4;  color:#ec0974;  text-align:center;border-left: 2px solid Green; border-right: 2px solid Green; border-bottom: 2px solid Green;   font-weight:bolder">
           <asp:Label ID="lblIntr3" runat="server" Text="Thanks for your cooperation to fill and provide us a genuine feedback!!!"></asp:Label>
          </td>
          </tr>
       <tr style="background-color:Silver">
      <td>1.</td>
      <td colspan="2">Please rate the following aspects of the job you are leaving. Use the 1 – 3 scale below</td>
     </tr>
    <%-- <tr>
      <td></td>
      <td></td>
      <td>1 Poor</td>
      <td>2</td>
      <td>3 Average</td>
      <td>4</td>
      <td>5 Excellent</td>
    </tr>--%>
     <tr>
      <td></td>
      <td>Type of work performed</td>
      <td><asp:RadioButtonList ID="rdblist7" runat="server" RepeatDirection="Horizontal">
      <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Salary</td>
      <td><asp:RadioButtonList ID="rdblist8" runat="server" RepeatDirection="Horizontal">
       <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Working conditions</td>
     <td><asp:RadioButtonList ID="rdblist9" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Tools and equipment provided</td>
      <td><asp:RadioButtonList ID="rdblist10" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Colleagues </td>
    <td><asp:RadioButtonList ID="rdblist11" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Supervision received</td>
     <td><asp:RadioButtonList ID="rdblist12" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Level of input in decisions that affected you</td>
      <td><asp:RadioButtonList ID="rdblist13" runat="server" RepeatDirection="Horizontal">
       <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr style="background-color:Silver">
      <td>2.</td>
      <td colspan="2">Please rate the following aspects of the organization overall. Use the 1 – 3 scale below.</td>
     </tr>
     <%-- <tr>
      <td></td>
      <td></td>
      <td>1 Poor</td>
      <td>2</td>
      <td>3 Average</td>
      <td>4</td>
      <td>5 Excellent</td>
    </tr>--%>
     <tr>
      <td></td>
      <td>Recruitment process</td>
     <td><asp:RadioButtonList ID="rdblist14" runat="server" RepeatDirection="Horizontal">
       <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>New employee orientation</td>
      <td><asp:RadioButtonList ID="rdblist15" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Training opportunities</td>
       <td><asp:RadioButtonList ID="rdblist16" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Career development opportunities</td>
       <td><asp:RadioButtonList ID="rdblist17" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Employee morale</td>
     <td><asp:RadioButtonList ID="rdblist18" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Fair treatment of employees</td>
     <td><asp:RadioButtonList ID="rdblist19" runat="server" RepeatDirection="Horizontal">
      <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Recognition for a job well done</td>
      <td><asp:RadioButtonList ID="rdblist20" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Communication </td>
     <td><asp:RadioButtonList ID="rdblist21" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Performance evaluation</td>
      <td><asp:RadioButtonList ID="rdblist22" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Commitment to customer service</td>
    <td><asp:RadioButtonList ID="rdblist23" runat="server" RepeatDirection="Horizontal">
       <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Concern for excellence</td>
     <td><asp:RadioButtonList ID="rdblist24" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Administrative polices/procedures</td>
    <td><asp:RadioButtonList ID="rdblist25" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="1">Poor</asp:ListItem>
       <asp:ListItem Value="2">Average</asp:ListItem>
       <asp:ListItem Value="3">Excellent</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr style="background-color:Silver">
      <td>3.</td>
      <td colspan="2">Please rate your supervisor on the following factors. Use the 1 – 5 scale below.</td>
    </tr>
     <tr>
      <td></td>
      <td>Provide usable performance feedback</td>
      <td><asp:RadioButtonList ID="rdblist26" runat="server" RepeatDirection="Horizontal">
      <asp:ListItem Value="1">Never</asp:ListItem>
      <asp:ListItem Value="2">Seldom</asp:ListItem>
       <asp:ListItem Value="3">Often</asp:ListItem>
      <asp:ListItem Value="4">Usually</asp:ListItem>
       <asp:ListItem Value="5">Always</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Recognized accomplishments</td>
    <td><asp:RadioButtonList ID="rdblist27" runat="server" RepeatDirection="Horizontal">
      <asp:ListItem Value="1">Never</asp:ListItem>
      <asp:ListItem Value="2">Seldom</asp:ListItem>
       <asp:ListItem Value="3">Often</asp:ListItem>
      <asp:ListItem Value="4">Usually</asp:ListItem>
       <asp:ListItem Value="5">Always</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Treated you fairly and respectfully</td>
      <td><asp:RadioButtonList ID="rdblist28" runat="server" RepeatDirection="Horizontal">
      <asp:ListItem Value="1">Never</asp:ListItem>
      <asp:ListItem Value="2">Seldom</asp:ListItem>
       <asp:ListItem Value="3">Often</asp:ListItem>
      <asp:ListItem Value="4">Usually</asp:ListItem>
       <asp:ListItem Value="5">Always</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Coached, trained, & developed </td>
      <td><asp:RadioButtonList ID="rdblist29" runat="server" RepeatDirection="Horizontal">
      <asp:ListItem Value="1">Never</asp:ListItem>
      <asp:ListItem Value="2">Seldom</asp:ListItem>
       <asp:ListItem Value="3">Often</asp:ListItem>
      <asp:ListItem Value="4">Usually</asp:ListItem>
       <asp:ListItem Value="5">Always</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Provided leadership</td>
      <td><asp:RadioButtonList ID="rdblist30" runat="server" RepeatDirection="Horizontal">
      <asp:ListItem Value="1">Never</asp:ListItem>
      <asp:ListItem Value="2">Seldom</asp:ListItem>
       <asp:ListItem Value="3">Often</asp:ListItem>
      <asp:ListItem Value="4">Usually</asp:ListItem>
       <asp:ListItem Value="5">Always</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Encouraged teamwork & cooperation</td>
     <td><asp:RadioButtonList ID="rdblist31" runat="server" RepeatDirection="Horizontal">
      <asp:ListItem Value="1">Never</asp:ListItem>
      <asp:ListItem Value="2">Seldom</asp:ListItem>
       <asp:ListItem Value="3">Often</asp:ListItem>
      <asp:ListItem Value="4">Usually</asp:ListItem>
       <asp:ListItem Value="5">Always</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Resolved concerns promptly</td>
     <td><asp:RadioButtonList ID="rdblist32" runat="server" RepeatDirection="Horizontal">
      <asp:ListItem Value="1">Never</asp:ListItem>
      <asp:ListItem Value="2">Seldom</asp:ListItem>
       <asp:ListItem Value="3">Often</asp:ListItem>
      <asp:ListItem Value="4">Usually</asp:ListItem>
       <asp:ListItem Value="5">Always</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Listened to suggestions & feedback</td>
    <td><asp:RadioButtonList ID="rdblist33" runat="server" RepeatDirection="Horizontal">
      <asp:ListItem Value="1">Never</asp:ListItem>
      <asp:ListItem Value="2">Seldom</asp:ListItem>
       <asp:ListItem Value="3">Often</asp:ListItem>
      <asp:ListItem Value="4">Usually</asp:ListItem>
       <asp:ListItem Value="5">Always</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Kept employees informed</td>
    <td><asp:RadioButtonList ID="rdblist34" runat="server" RepeatDirection="Horizontal">
      <asp:ListItem Value="1">Never</asp:ListItem>
      <asp:ListItem Value="2">Seldom</asp:ListItem>
       <asp:ListItem Value="3">Often</asp:ListItem>
      <asp:ListItem Value="4">Usually</asp:ListItem>
       <asp:ListItem Value="5">Always</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr>
      <td></td>
      <td>Provided appropriate & challenging assignments</td>
   <td><asp:RadioButtonList ID="rdblist35" runat="server" RepeatDirection="Horizontal">
      <asp:ListItem Value="1">Never</asp:ListItem>
      <asp:ListItem Value="2">Seldom</asp:ListItem>
       <asp:ListItem Value="3">Often</asp:ListItem>
      <asp:ListItem Value="4">Usually</asp:ListItem>
       <asp:ListItem Value="5">Always</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr style="background-color:Silver">
      <td>4.</td>
      <td colspan="2">Did dissatisfaction with any of the following factors influence your decision to leave?</td>       
    </tr>
    <tr>
      <td></td>
      <td>Type of work</td>
      <td><asp:RadioButtonList ID="rdblist1" runat="server" RepeatDirection="Horizontal">
      <asp:ListItem Value="0">YES</asp:ListItem>
      <asp:ListItem Value="1">NO</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
    <tr>
      <td></td>
      <td>Working conditions (setting, schedule, travel, flexibility)</td>
      <td><asp:RadioButtonList ID="rdblist2" runat="server" RepeatDirection="Horizontal">
      <asp:ListItem Value="0">YES</asp:ListItem>
      <asp:ListItem Value="1">NO</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
    <tr>
      <td></td>
      <td>Pay(benefits)</td>
       <td><asp:RadioButtonList ID="rdblist3" runat="server" RepeatDirection="Horizontal">
      <asp:ListItem Value="0">YES</asp:ListItem>
      <asp:ListItem Value="1">NO</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
    <tr>
      <td></td>
      <td>Supervisor/Leadership</td>
     <td><asp:RadioButtonList ID="rdblist4" runat="server" RepeatDirection="Horizontal">
      <asp:ListItem Value="0">YES</asp:ListItem>
      <asp:ListItem Value="1">NO</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
    <tr>
      <td></td>
      <td>Nature of the job</td>
       <td><asp:RadioButtonList ID="rdblist5" runat="server" RepeatDirection="Horizontal">
      <asp:ListItem Value="0">YES</asp:ListItem>
      <asp:ListItem Value="1">NO</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
    <tr>
      <td></td>
      <td>Location</td>
      <td><asp:RadioButtonList ID="rdblist6" runat="server" RepeatDirection="Horizontal">
      <asp:ListItem Value="0">YES</asp:ListItem>
      <asp:ListItem Value="1">NO</asp:ListItem>
      </asp:RadioButtonList></td>
    </tr>
     <tr style="background-color:Silver">
      <td>5.</td>
      <td colspan="2">If you accepted another job, please complete the following.(Optional)</td>
    </tr>
     <tr>
      <td></td>
      <td >Please describe the primary reason(s) you are leaving your current position.</td>
     <td ><asp:TextBox ID="txtPrime" runat="server" Width="99%" TextMode="MultiLine"></asp:TextBox></td>
    </tr>  
     <tr>
      <td></td>
      <td>Name of new employer(Optional)</td>
      <td><asp:TextBox ID="txtEmployerName" runat="server" Width="98%"></asp:TextBox></td>
    </tr>
     <tr>
      <td></td>
      <td>Location of position(Optional)</td>
      <td><asp:TextBox ID="txtPosLoc" runat="server" Width="98%"></asp:TextBox></td>
    </tr>
     <tr>
      <td></td>
      <td>Title of position</td>
      <td><asp:TextBox ID="txtPosTitle" runat="server" Width="98%"></asp:TextBox></td>
    </tr>
     <tr>
      <td></td>
      <td>Nature of work of position</td>
      <td><asp:TextBox ID="txtPosNature" runat="server" Width="98%"></asp:TextBox></td>
    </tr>
     <tr>
      <td></td>
      <td>Salary of position</td>
      <td><asp:TextBox ID="txtPosSalary" runat="server" Width="98%"></asp:TextBox></td>
    </tr>
     <tr>
      <td></td>
      <td>What the new position and/or organization offers that we do not.</td>
      <td><asp:TextBox ID="txtNewOffer" runat="server" Width="98%"></asp:TextBox></td>
    </tr>
    <tr style="background-color:Silver">
      <td>6.</td>
      <td colspan="2">Do you have any other comments or suggestions?</td>
    </tr>
    <tr>
    <td colspan="3">
     <asp:TextBox ID="txtComment" runat="server"  TextMode="MultiLine" Width="98%"></asp:TextBox><br />
    </td>
    </tr>
     </table>
 </div>
  <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="Button" />
    
</td>
 </tr>
  </table>
  </asp:panel><br />
 </div>
 <asp:Panel ID="pnl2" runat="server" Width="100%" Visible="false">
 <table width="100%">
   <tr>
     <td>
      <div style="height:385px; overflow:auto;">
          <asp:GridView ID="grvFeedback" runat="server" 
           EmptyDataText="No Feedback" 
           AutoGenerateColumns="false"
           DataKeyNames="Guid"
           OnRowEditing="grvFeedback_RowEditing" Width="100%"
           HeaderStyle-BackColor="#ACBA82"
           HeaderStyle-ForeColor="White">
           <Columns>
             <asp:TemplateField HeaderText="Comment" HeaderStyle-Width="40%">
               <ItemTemplate>
                 <asp:Label ID="lblPrimaryReason" runat="server" Text='<%# Eval("PrimaryReason") %>'></asp:Label>
               </ItemTemplate>
             </asp:TemplateField>
             <asp:CommandField EditText="Read More..." ShowEditButton="true" ShowCancelButton="false" CausesValidation="false" HeaderStyle-Width="5%"/>
           </Columns>
         </asp:GridView>
      </div>
     </td>
   </tr>
 </table>
 </asp:Panel>
    
  <%--<asp:Panel id ="pnlLog" runat="Server" Visible="false">
      <div id="divAll"  style="position:absolute; width:100%; height:174%; background-color:Gray; z-index:800; opacity:.8; filter:Alpha(opacity=70); top: 0px; left: 0px; "  >
       <!-- style="padding-left:14%; padding-right:14%"-->
      
          <asp:Button ID="imgbtn" runat="server"  OnClick="imgbtn_Click"  CausesValidation="false" style="float: right; background-color:#ff0000" Text="X" />
           --%><table width="100%" style="height: 599px">
    <tr>
      <td align="center" valign="middle">
        <asp:Login ID="UserLogin" runat="server" DestinationPageUrl="~/pHome.aspx" 
         OnAuthenticate="UserLogin_Authenticate" Height="207px" Width="342px" 
              BackColor="#ACBA82" TitleTextStyle-ForeColor="White" TitleTextStyle-Font-Size="Large" 
         TextBoxStyle-BackColor="#E9EEDE" LoginButtonStyle-BackColor="#E9EEDE"  
             Font-Names="Arial" Font-Size="Medium" DisplayRememberMe="false"  BorderStyle="Solid" BorderWidth="2px" BorderColor="White">
        </asp:Login>
      </td>
    </tr>
  </table>
            
        
<%--          </div>
      </asp:Panel>--%>
        
</asp:Content>

