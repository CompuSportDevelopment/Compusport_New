<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPageMain.master" AutoEventWireup="true" CodeFile="Process.aspx.cs" Inherits="TeacherInfo_Process" Title="SwingModel - Modeling Techniques" %>
<%@ Register Src="~/Controls/TeacherInfoMenu.ascx" TagName="TeacherInfoMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="submenu">
        <uc1:TeacherInfoMenu ID="TeacherInfoMenu1" runat="server" />
    </div>
    <p class="pagetitle">Modeling Techniques</p>
    <p>
        <asp:Image ID="Image1" runat="server" ImageAlign="Left" ImageUrl="~/Images/800px-Stickmen.jpg" />
        In 1976, Dr. Ralph Mann completed his studies for his Ph.D. in Biomechanics by 
        submitting his dissertation titled “A Comprehensive Computer Technique to 
        Process Human Motion Data”. Using a common jumping action, the technique was 
        designed to maximize the motion by estimating the potential maximum human effort 
        possible, then predicting the simulated result.</p>
    <p>
        The process worked so well that Dr. Mann continued to develop the technique when 
        he became the director of the biomechanics program at the University of 
        Kentucky. Since the core of the technique required information on maximum human 
        performance, he began using elite athletes in each of the major sports to 
        determine these values. The process use to determine the Model values for any 
        sport consisted of:</p>
    <p>
        <asp:BulletedList ID="BulletedList1" runat="server" BulletStyle="Numbered">
            <asp:ListItem>Film a large number of elite athletes performing the movement of 
            interest.</asp:ListItem>
            <asp:ListItem>Follow the body motion of each athlete by digitizing the athlete’s 
            performance into a computer. This entails telling the computer where each of the 
            body segments, along with any implement (golf club, bat, etc.), was located 
            during each frame of the performance.</asp:ListItem>
            <asp:ListItem>Employ statistics to determine the maximum human effort possible 
            for each of the body segments.</asp:ListItem>
            <asp:ListItem>Using these values, build a performance Model using the Modeling 
            techniques that were further developed from his dissertation. </asp:ListItem>
        </asp:BulletedList>
    <p>
        <asp:Image ID="Image2" runat="server" ImageAlign="Right" ImageUrl="~/Images/StickModel1.jpg" />
        Initially, a crude ten segment stick figure Model was employed to produce the 
        simulations. The resulting animations, in every sport, were so visually 
        appealing that Dr. Mann began using the results to demonstrate the potential 
        future performance of each spot action.</p>
    <p>
        In addition, the modeling efforts pointed to the conclusion that every athlete 
        in the elite group were performing their movements very much like every other 
        athlete in the elite group. There were obvious differences due to body build and 
        individual idiosyncrasies, however, these were minor when they were accounted 
        for.</p>
    <p>
        <asp:Image ID="Image3" runat="server" ImageAlign="Left" ImageUrl="~/Images/modelsetupangle.png" />
        Since its inception, the stick figure Model has evolved into a three 
        dimensional, multi-segment entity.</p>
    <p>
        More importantly, in the process of attempting to use the Model to show students 
        how they can swing more like the best players in the game, Dr. Mann solved the 
        problem of body size (and equipment) differences by having the Model adapt to 
        the body size of any student.</p>
    <p>
        So, now the Model changes due to the differences of everything from the major 
        influences like height to the small effects of something like shoe size.</p>
    <p>
        In addition, since most students cannot generate a Driver clubhead speed of 125 
        miles per hour, or sprint at 30 miles per hour, the performance speed of the 
        Model can also be selected.</p>
    <p>
        <asp:Image ID="Image4" runat="server" ImageAlign="Right" ImageUrl="~/Images/CarlLewisStick.jpg" />
        Since each student’s Model matches their body (and equipment) size, it can be 
        used to show the student how their performance compares to an elite performance.</p>
    <p>
        This process has been used to help students ranging from elite sprinters to 
        beginning golfers identify where they stand when compared to the best in the 
        world.</p>
    <p>
        And to show the comparisons, Dr. Mann combined video and computer graphics to 
        overlay the model image on the actual performance of the student. This visual 
        comparison makes it easy to see the performance differences, thus making the job 
        of the teacher much easier.</p>
    <p>
        Not only can the student see where they have to improve when they start, but 
        they can easily see improvement as they progress. The goal of the teacher is 
        simply to move their student closer to their Model.</p>
    <div style="float: left; width: 410px;">
        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,16,0"
            width="400" height="300" id="flash1" name="flash1">
            <param name="movie" value="http://www.swingmodel.com/Images/ModelSide.swf">
            <param name="quality" value="high">
            <param name="play" value="true">
            <param name="loop" value="true">
            <embed id="flash1" name="flash1" src="http://www.swingmodel.com/Images/ModelSide.swf" width="400" height="300" play="true" loop="true"
                quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"></embed>
        </object>
    </div>
    <div style="float: left; width: 511px;">
    <p>
        The final evolutionary process of displaying Model results comes with 3D 
        Humanoid Models. Using the skeletal frame that makes up the advanced stick 
        figure, a humanoid figure can be added to make the simulated motion all the more 
        realistic.</p>
    <p>
        The SwingModel golf Driver performance is animated to the left. 
        By incorporating the best movement patterns of the best PGA players in the game, 
        this performance is superior to any of its parts.</p>
    <p>
        As a teacher, this modeling technique can be used to show your students how, with their body
        size, can swing like the best players in the game.  Instead of trying to make them swing like
        a good player that cannot match their body size or swing speed, the SwingModel process can
        show you how to help them develop the best swing matched to their exact body dimensions and
        swing speed.</p>
    </div>
    <p class="pagetitle" style="width: 100%;">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TeacherInfo/GolfModeling.aspx">Continue Tour</asp:HyperLink>
        or
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/TeacherInfo/Default.aspx">Return to Teacher Tour Home</asp:HyperLink></p>
</asp:Content>
