<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AthleteForceData.ascx.cs"
    Inherits="Controls_AthleteForceData" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="SMSoftCharts" Namespace="SMSoftCharts" TagPrefix="sm" %>
<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager> 
<asp:Table ID="Table1" runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <p class="summarytitle">
                My Athlete Force Data:<asp:Label ID="lblSelectedAthlete" runat="server"></asp:Label></p>
        </asp:TableCell>
        <asp:TableCell Width="15%" HorizontalAlign="Right">
                <input type="button" value="Select New Member" onclick="javascript: history.go(-1)"/>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<ajaxToolkit:TabContainer runat="server" ID="Tabs" CssClass="ajax__tab_xp">
        <ajaxToolkit:TabPanel runat="server" ID="TabPanel2" HeaderText="Initial Back Block Data">
        <ContentTemplate>
            <p class="summarytitle">
                Initial Back Block Data -
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label></p>
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            <p>
                This Section displays the Block Force results from the Athlete’s Back leg recorded
                during their earliest Start Session. You can use these results to compare them to
                their most recent (Current) or any subsequent (Other) Session when forces were recorded.
            </p>
            <br />
            <ajaxToolkit:Accordion ID="Accordion2" runat="server" HeaderCssClass="accordionHeader"
                HeaderSelectedCssClass="accordionHeaderSelected">
                <Panes>
                    <ajaxToolkit:AccordionPane ID="AccordionPane5" runat="server">
                        <Header>
                            Actual Forces</Header>
                        <Content>
                            <asp:Image ID="Image11" runat="server" />
                            <asp:Image ID="Image12" runat="server" />
                            <asp:Image ID="Image13" runat="server" />
                            <asp:Label ID="lblInitialBackAF" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="AFInitialBackBlockData" runat="server">
                                These graphs show the Actual Forces (in kilograms) that are exerted on the Back
                                block during the Start. These results are a good indication as to whether the athlete
                                can produce the level of force required to produce a successful start.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) average force created on the
                                back block during the starting action. The position of the pointer indicates the
                                force that the Athlete created. The color bars along the dial indicate the forces
                                that are achieved by average (red), good (yellow), and world class (green) starters.
                                The second gauge displays the Vertical (upward) average force, while the third gauge
                                indicates the combined Total (Horizontal and Vertical) average force. The results
                                are outstanding if the average is within the green zone, acceptable if within the
                                yellow zone, and in need of improvement if in the red zone. If the Athlete falls
                                within the green zone, they will typically be in the front at the 10 meter mark
                                of the race. If they are in the yellow zone, they will typically be in the middle
                                of the pack at the beginning of the race. Finally, if they are in the red zone,
                                they will typically be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal force while minimizing the Vertical
                                force. The Total force should be maximized, but only by having a large Horizontal
                                component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane6" runat="server">
                        <Header>
                            Relative Forces</Header>
                        <Content>
                            <asp:Image ID="Image14" runat="server" />
                            <asp:Image ID="Image15" runat="server" />
                            <asp:Image ID="Image16" runat="server" />
                             <asp:Label ID="lblInitialBackRF" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="RFInitialBackBlockData" runat="server">
                                Due to the differences in athlete’s weights, direct comparison of the Actual Forces
                                can be misleading. These graphs show the Relative (percentage of the athlete’s Model)
                                Forces that are exerted on the Back block during the Start, which can be used to
                                compare any two athletes.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) relative force created on
                                the back block during the starting action. The position of the pointer indicates
                                the force that the Athlete created, as a percentage of their Model (World Record
                                force level). The color bars along the dial indicate the percentages that are achieved
                                by average (red), good (yellow), and world class (green) starters. The second gauge
                                displays the Vertical (upward) average percentage, while the third gauge indicates
                                the combined Total (Horizontal and Vertical) percentage. The results are outstanding
                                if the average is within the green zone, acceptable if within the yellow zone, and
                                in need of improvement if in the red zone. If the Athlete falls within the green
                                zone, they will typically be in the front at the 10 meter mark of the race. If they
                                are in the yellow zone, they will typically be in the middle of the pack at the
                                beginning of the race. Finally, if they are in the red zone, they will typically
                                be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal power while minimizing the Vertical
                                power. The Total power should be maximized, but only by having a large Horizontal
                                component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane7" runat="server">
                        <Header>
                            Actual Power</Header>
                        <Content>
                            <div style="text-align: center;">
                                <asp:Image ID="Image17" runat="server" />
                                <asp:Image ID="Image18" runat="server" />
                                <asp:Image ID="Image63" runat="server" />
                               
                            </div>
                             <asp:Label ID="lblInitialBackAP" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="APInitialBackBlockData" runat="server">
                                These graphs show the Actual Power (in kilograms/meters/second) that is generated
                                on the Back block during the Start. These results are a good indication as to whether
                                the athlete is explosive enough to produce a successful start.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) average power created on the
                                back block during the starting action. The position of the pointer indicates the
                                power that the Athlete created. The color bars along the dial indicate the power
                                that is achieved by average (red), good (yellow), and world class (green) starters.
                                The second gauge displays the Vertical (upward) average power, while the third gauge
                                indicates the combined Total (Horizontal and Vertical) average power. The results
                                are outstanding if the average is within the green zone, acceptable if within the
                                yellow zone, and in need of improvement if in the red zone. If the Athlete falls
                                within the green zone, they will typically be in the front at the 10 meter mark
                                of the race. If they are in the yellow zone, they will typically be in the middle
                                of the pack at the beginning of the race. Finally, if they are in the red zone,
                                they will typically be behind during the initial portion of the race
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal power while minimizing the Vertical
                                power. The Total power should be maximized, but only by having a large Horizontal
                                component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane8" runat="server">
                        <Header>
                            Relative Power</Header>
                        <Content>
                            <div style="text-align: center;">
                                <asp:Image ID="Image19" runat="server" />
                                <asp:Image ID="Image20" runat="server" />
                                <asp:Image ID="Image64" runat="server" />
                               
                            </div>
                             <asp:Label ID="lblInitialBackRP" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="RPInitialBackBlockData" runat="server">
                                Due to the differences in athlete’s weights, direct comparison of the Actual Power
                                can be misleading. These graphs show the Relative (percentage of the athlete’s Model)
                                Power that is exerted on the Back block during the Start, which can be used to compare
                                any two athletes.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) relative power created on
                                the back block during the starting action. The position of the pointer indicates
                                the power that the Athlete created, as a percentage of their Model (World Record
                                force level). The color bars along the dial indicate the percentages that are achieved
                                by average (red), good (yellow), and world class (green) starters. The second gauge
                                displays the Vertical (upward) average percentage, while the third gauge indicates
                                the combined Total (Horizontal and Vertical) percentage. The results are outstanding
                                if the average is within the green zone, acceptable if within the yellow zone, and
                                in need of improvement if in the red zone. If the Athlete falls within the green
                                zone, they will typically be in the front at the 10 meter mark of the race. If they
                                are in the yellow zone, they will typically be in the middle of the pack at the
                                beginning of the race. Finally, if they are in the red zone, they will typically
                                be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal percentage while minimizing the
                                Vertical percentage. The Total percentage should be maximized, but only by having
                                a large Horizontal component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                </Panes>
            </ajaxToolkit:Accordion>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>


    <ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="Current Back Block Data">
        <ContentTemplate>
            <p class="summarytitle">
                Current Back Block Data -
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></p>
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            
            <p>
               This Section displays the Block Force results from the Athlete’s Back leg recorded
                during their most recent Start Session. You can use these results to determine their
                current ability to produce a successful Start, as well as compare them to their
                first (Initial) or any subsequent (Other) Session when forces were recorded.
            </p>
            <br />
            <ajaxToolkit:Accordion ID="Accordion1" runat="server" HeaderCssClass="accordionHeader"
                        HeaderSelectedCssClass="accordionHeaderSelected">

                <Panes>
                <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                        <Header>
                            Actual Forces</Header>
                    
                        <Content>
                            <asp:Image ID="Image1" runat="server" />
                            <asp:Image ID="Image7" runat="server" />
                            <asp:Image ID="Image8" runat="server" />
                            <asp:Label ID="lblCurrentBackAF" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="AFCurrentBackBlockData" runat="server">
                                These graphs show the Actual Forces (in kilograms) that are exerted on the Back
                                block during the Start. These results are a good indication as to whether the athlete
                                can produce the level of force required to produce a successful start.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) average force created on the
                                back block during the starting action. The position of the pointer indicates the
                                force that the Athlete created. The color bars along the dial indicate the forces
                                that are achieved by average (red), good (yellow), and world class (green) starters.
                                The second gauge displays the Vertical (upward) average force, while the third gauge
                                indicates the combined Total (Horizontal and Vertical) average force. The results
                                are outstanding if the average is within the green zone, acceptable if within the
                                yellow zone, and in need of improvement if in the red zone. If the Athlete falls
                                within the green zone, they will typically be in the front at the 10 meter mark
                                of the race. If they are in the yellow zone, they will typically be in the middle
                                of the pack at the beginning of the race. Finally, if they are in the red zone,
                                they will typically be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal force while minimizing the Vertical
                                force. The Total force should be maximized, but only by having a large Horizontal
                                component.
                                <br />
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                        <Header>
                            Relative Forces</Header>
                        <Content>
                            <asp:Image ID="Image9" runat="server" />
                            <asp:Image ID="Image2" runat="server" />
                            <asp:Image ID="Image10" runat="server" />
                            <asp:Label ID="lblCurrentBackRF" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="RFCurrentBackBlockData" runat="server">
                                Due to the differences in athlete’s weights, direct comparison of the Actual Forces
                                can be misleading. These graphs show the Relative (percentage of the athlete’s Model)
                                Forces that are exerted on the Back block during the Start, which can be used to
                                compare any two athletes.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) relative force created on
                                the back block during the starting action. The position of the pointer indicates
                                the force that the Athlete created, as a percentage of their Model (World Record
                                force level). The color bars along the dial indicate the percentages that are achieved
                                by average (red), good (yellow), and world class (green) starters. The second gauge
                                displays the Vertical (upward) average percentage, while the third gauge indicates
                                the combined Total (Horizontal and Vertical) percentage. The results are outstanding
                                if the average is within the green zone, acceptable if within the yellow zone, and
                                in need of improvement if in the red zone. If the Athlete falls within the green
                                zone, they will typically be in the front at the 10 meter mark of the race. If they
                                are in the yellow zone, they will typically be in the middle of the pack at the
                                beginning of the race. Finally, if they are in the red zone, they will typically
                                be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal percentage while minimizing the
                                Vertical percentage. The Total percentage should be maximized, but only by having
                                a large Horizontal component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                        <Header>
                            Actual Power</Header>
                        <Content>
                            <div style="text-align: center;">
                                <asp:Image ID="Image3" runat="server" />
                                <asp:Image ID="Image4" runat="server" />
                                <asp:Image ID="Image61" runat="server" />
                               
                            </div>
                             <asp:Label ID="lblCurrentBackAP" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="APCurrentBackBlockData" runat="server">
                                These graphs show the Actual Power (in kilograms/meters/second) that is generated
                                on the Back block during the Start. These results are a good indication as to whether
                                the athlete is explosive enough to produce a successful start.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) average power created on the
                                back block during the starting action. The position of the pointer indicates the
                                power that the Athlete created. The color bars along the dial indicate the power
                                that is achieved by average (red), good (yellow), and world class (green) starters.
                                The second gauge displays the Vertical (upward) average power, while the third gauge
                                indicates the combined Total (Horizontal and Vertical) average power. The results
                                are outstanding if the average is within the green zone, acceptable if within the
                                yellow zone, and in need of improvement if in the red zone. If the Athlete falls
                                within the green zone, they will typically be in the front at the 10 meter mark
                                of the race. If they are in the yellow zone, they will typically be in the middle
                                of the pack at the beginning of the race. Finally, if they are in the red zone,
                                they will typically be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal power while minimizing the Vertical
                                power. The Total power should be maximized, but only by having a large Horizontal
                                component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                        <Header>
                            Relative Power</Header>
                        <Content>
                            <div style="text-align: center;">
                                <asp:Image ID="Image5" runat="server" />
                                <asp:Image ID="Image6" runat="server" />
                                <asp:Image ID="Image62" runat="server" />
                                
                            </div>
                           <asp:Label ID="lblCurrentBackRP" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="RPCurrentBackBlockData" runat="server">
                                Due to the differences in athlete’s weights, direct comparison of the Actual Power
                                can be misleading. These graphs show the Relative (percentage of the athlete’s Model)
                                Power that is exerted on the Back block during the Start, which can be used to compare
                                any two athletes.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) relative power created on
                                the back block during the starting action. The position of the pointer indicates
                                the power that the Athlete created, as a percentage of their Model (World Record
                                force level). The color bars along the dial indicate the percentages that are achieved
                                by average (red), good (yellow), and world class (green) starters. The second gauge
                                displays the Vertical (upward) average percentage, while the third gauge indicates
                                the combined Total (Horizontal and Vertical) percentage. The results are outstanding
                                if the average is within the green zone, acceptable if within the yellow zone, and
                                in need of improvement if in the red zone. If the Athlete falls within the green
                                zone, they will typically be in the front at the 10 meter mark of the race. If they
                                are in the yellow zone, they will typically be in the middle of the pack at the
                                beginning of the race. Finally, if they are in the red zone, they will typically
                                be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal percentage while minimizing the
                                Vertical percentage. The Total percentage should be maximized, but only by having
                                a large Horizontal component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                </Panes>
            </ajaxToolkit:Accordion>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>

    <ajaxToolkit:TabPanel runat="server" ID="TabPanel3" HeaderText="Other Back Block Data">
        <ContentTemplate>
            <div style="float: left; width: 70%; padding: 19px 0px 19px 0px;">
                <p class="summarytitle">
                    Other Back Block Data -
                    <asp:Label ID="Label5" runat="server" Text=""></asp:Label></p>
            </div>
            <div style="float: left; width: 30%; text-align: right; padding: 19px 0px 19px 0px;">
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_Changed"
                    AutoPostBack="true">
                    <asp:ListItem Value="0">Select Teaching Session</asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
             <br />
            <p>
                This Section displays the Block Force results from the Athlete’s Back leg recorded
                during all Sessions that occurred between their Initial and Current Sessions. You
                can use these results to determine their progress from their first (Initial) to
                their most recent (Current) Session when forces were recorded
            </p>
            <ajaxToolkit:Accordion ID="Accordion3" runat="server" HeaderCssClass="accordionHeader"
                HeaderSelectedCssClass="accordionHeaderSelected">
                <Panes>
                    <ajaxToolkit:AccordionPane ID="AccordionPane9" runat="server">
                        <Header>
                            Actual Forces</Header>
                        <Content>
                            <asp:Image ID="Image41" runat="server" />
                            <asp:Image ID="Image42" runat="server" />
                            <asp:Image ID="Image43" runat="server" />
                            <asp:Label ID="lblOtherBackAF" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="owdp" runat="server">
                                These graphs show the Actual Forces (in kilograms) that are exerted on the Back
                                block during the Start. These results are a good indication as to whether the athlete
                                can produce the level of force required to produce a successful start.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) average force created on the
                                back block during the starting action. The position of the pointer indicates the
                                force that the Athlete created. The color bars along the dial indicate the forces
                                that are achieved by average (red), good (yellow), and world class (green) starters.
                                The second gauge displays the Vertical (upward) average force, while the third gauge
                                indicates the combined Total (Horizontal and Vertical) average force. The results
                                are outstanding if the average is within the green zone, acceptable if within the
                                yellow zone, and in need of improvement if in the red zone. If the Athlete falls
                                within the green zone, they will typically be in the front at the 10 meter mark
                                of the race. If they are in the yellow zone, they will typically be in the middle
                                of the pack at the beginning of the race. Finally, if they are in the red zone,
                                they will typically be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal force while minimizing the Vertical
                                force. The Total force should be maximized, but only by having a large Horizontal
                                component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane10" runat="server">
                        <Header>
                            Relative Forces</Header>
                        <Content>
                            <asp:Image ID="Image44" runat="server" />
                            <asp:Image ID="Image45" runat="server" />
                            <asp:Image ID="Image46" runat="server" />
                            <asp:Label ID="lblOtherBackRF" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="owsp" runat="server">
                                Due to the differences in athlete’s weights, direct comparison of the Actual Forces
                                can be misleading. These graphs show the Relative (percentage of the athlete’s Model)
                                Forces that are exerted on the Back block during the Start, which can be used to
                                compare any two athletes.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) relative force created on
                                the back block during the starting action. The position of the pointer indicates
                                the force that the Athlete created, as a percentage of their Model (World Record
                                force level). The color bars along the dial indicate the percentages that are achieved
                                by average (red), good (yellow), and world class (green) starters. The second gauge
                                displays the Vertical (upward) average percentage, while the third gauge indicates
                                the combined Total (Horizontal and Vertical) percentage. The results are outstanding
                                if the average is within the green zone, acceptable if within the yellow zone, and
                                in need of improvement if in the red zone. If the Athlete falls within the green
                                zone, they will typically be in the front at the 10 meter mark of the race. If they
                                are in the yellow zone, they will typically be in the middle of the pack at the
                                beginning of the race. Finally, if they are in the red zone, they will typically
                                be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal percentage while minimizing the
                                Vertical percentage. The Total percentage should be maximized, but only by having
                                a large Horizontal component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane11" runat="server">
                        <Header>
                            Actual Power</Header>
                        <Content>
                            <div style="text-align: left;">
                                <asp:Image ID="Image47" runat="server" />
                                <asp:Image ID="Image48" runat="server" />
                                <asp:Image ID="Image65" runat="server" />
                                <asp:Label ID="lblOtherBackAP" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            </div>
                            <p id="owlp" runat="server">
                                These graphs show the Actual Power (in kilograms/meters/second) that is generated
                                on the Back block during the Start. These results are a good indication as to whether
                                the athlete is explosive enough to produce a successful start.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) average power created on the
                                back block during the starting action. The position of the pointer indicates the
                                power that the Athlete created. The color bars along the dial indicate the power
                                that is achieved by average (red), good (yellow), and world class (green) starters.
                                The second gauge displays the Vertical (upward) average power, while the third gauge
                                indicates the combined Total (Horizontal and Vertical) average power. The results
                                are outstanding if the average is within the green zone, acceptable if within the
                                yellow zone, and in need of improvement if in the red zone. If the Athlete falls
                                within the green zone, they will typically be in the front at the 10 meter mark
                                of the race. If they are in the yellow zone, they will typically be in the middle
                                of the pack at the beginning of the race. Finally, if they are in the red zone,
                                they will typically be behind during the initial portion of the race
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane12" runat="server">
                        <Header>
                            Relative Power</Header>
                        <Content>
                            <div style="text-align: left">
                                <asp:Image ID="Image49" runat="server" />
                                <asp:Image ID="Image50" runat="server" />
                                <asp:Image ID="Image66" runat="server" />
                                 <asp:Label ID="lblOtherBackRP" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            </div>
                            <p id="owsdp" runat="server">
                                Due to the differences in athlete’s weights, direct comparison of the Actual Power
                                can be misleading. These graphs show the Relative (percentage of the athlete’s Model)
                                Power that is exerted on the Back block during the Start, which can be used to compare
                                any two athletes.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) relative power created on
                                the back block during the starting action. The position of the pointer indicates
                                the power that the Athlete created, as a percentage of their Model (World Record
                                force level). The color bars along the dial indicate the percentages that are achieved
                                by average (red), good (yellow), and world class (green) starters. The second gauge
                                displays the Vertical (upward) average percentage, while the third gauge indicates
                                the combined Total (Horizontal and Vertical) percentage. The results are outstanding
                                if the average is within the green zone, acceptable if within the yellow zone, and
                                in need of improvement if in the red zone. If the Athlete falls within the green
                                zone, they will typically be in the front at the 10 meter mark of the race. If they
                                are in the yellow zone, they will typically be in the middle of the pack at the
                                beginning of the race. Finally, if they are in the red zone, they will typically
                                be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal percentage while minimizing the
                                Vertical percentage. The Total percentage should be maximized, but only by having
                                a large Horizontal component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                </Panes>
            </ajaxToolkit:Accordion>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="TabPanel5" HeaderText="Initial Front Block Data">
        <ContentTemplate>
            <p class="summarytitle">
                Initial Front Block Data -
                <asp:Label ID="Label9" runat="server" Text=""></asp:Label></p>
            <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
            <p>
                This Section displays the Block Force results from the Athlete’s Front leg recorded
                during their earliest Start Session. You can use these results to compare them to
                their most recent (Current) or any subsequent (Other) Session when forces were recorded.
            </p>
            <br />
            <ajaxToolkit:Accordion ID="Accordion5" runat="server" HeaderCssClass="accordionHeader"
                HeaderSelectedCssClass="accordionHeaderSelected">
                <Panes>
                    <ajaxToolkit:AccordionPane ID="AccordionPane17" runat="server">
                        <Header>
                            Actual Forces</Header>
                        <Content>
                            <asp:Image ID="Image31" runat="server" />
                            <asp:Image ID="Image32" runat="server" />
                            <asp:Image ID="Image33" runat="server" />
                            <asp:Label ID="lblInitialFrontAF" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="AFInitialFrontBlockData" runat="server">
                                These graphs show the Actual Forces (in kilograms) that are exerted on the Front
                                block during the Start. These results are a good indication as to whether the athlete
                                can produce the level of force required to produce a successful start.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) average force created on the
                                back block during the starting action. The position of the pointer indicates the
                                force that the Athlete created. The color bars along the dial indicate the forces
                                that are achieved by average (red), good (yellow), and world class (green) starters.
                                The second gauge displays the Vertical (upward) average force, while the third gauge
                                indicates the combined Total (Horizontal and Vertical) average force. The results
                                are outstanding if the average is within the green zone, acceptable if within the
                                yellow zone, and in need of improvement if in the red zone. If the Athlete falls
                                within the green zone, they will typically be in the front at the 10 meter mark
                                of the race. If they are in the yellow zone, they will typically be in the middle
                                of the pack at the beginning of the race. Finally, if they are in the red zone,
                                they will typically be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal force while minimizing the Vertical
                                force. The Total force should be maximized, but only by having a large Horizontal
                                component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane18" runat="server">
                        <Header>
                            Relative Forces</Header>
                        <Content>
                            <asp:Image ID="Image34" runat="server" />
                            <asp:Image ID="Image35" runat="server" />
                            <asp:Image ID="Image36" runat="server" />
                            <asp:Label ID="lblInitialFrontRF" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="RFInitialFrontBlockData" runat="server">
                                Due to the differences in athlete’s weights, direct comparison of the Actual Forces
                                can be misleading. These graphs show the Relative (percentage of the athlete’s Model)
                                Forces that are exerted on the Front block during the Start, which can be used to
                                compare any two athletes.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) relative force created on
                                the back block during the starting action. The position of the pointer indicates
                                the force that the Athlete created, as a percentage of their Model (World Record
                                force level). The color bars along the dial indicate the percentages that are achieved
                                by average (red), good (yellow), and world class (green) starters. The second gauge
                                displays the Vertical (upward) average percentage, while the third gauge indicates
                                the combined Total (Horizontal and Vertical) percentage. The results are outstanding
                                if the average is within the green zone, acceptable if within the yellow zone, and
                                in need of improvement if in the red zone. If the Athlete falls within the green
                                zone, they will typically be in the front at the 10 meter mark of the race. If they
                                are in the yellow zone, they will typically be in the middle of the pack at the
                                beginning of the race. Finally, if they are in the red zone, they will typically
                                be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal percentage while minimizing the
                                Vertical percentage. The Total percentage should be maximized, but only by having
                                a large Horizontal component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane19" runat="server">
                        <Header>
                            Actual Power</Header>
                        <Content>
                            <div style="text-align: center;">
                                <asp:Image ID="Image37" runat="server" />
                                <asp:Image ID="Image38" runat="server" />
                                <asp:Image ID="Image69" runat="server" />
                               
                            </div>
                             <asp:Label ID="lblInitialFrontAP" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="APInitialFrontBlockData" runat="server">
                                These graphs show the Actual Power (in kilograms/meters/second) that is generated
                                on the Front block during the Start. These results are a good indication as to whether
                                the athlete is explosive enough to produce a successful start.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) average power created on the
                                back block during the starting action. The position of the pointer indicates the
                                power that the Athlete created. The color bars along the dial indicate the power
                                that is achieved by average (red), good (yellow), and world class (green) starters.
                                The second gauge displays the Vertical (upward) average power, while the third gauge
                                indicates the combined Total (Horizontal and Vertical) average power. The results
                                are outstanding if the average is within the green zone, acceptable if within the
                                yellow zone, and in need of improvement if in the red zone. If the Athlete falls
                                within the green zone, they will typically be in the front at the 10 meter mark
                                of the race. If they are in the yellow zone, they will typically be in the middle
                                of the pack at the beginning of the race. Finally, if they are in the red zone,
                                they will typically be behind during the initial portion of the race
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal power while minimizing the Vertical
                                power. The Total power should be maximized, but only by having a large Horizontal
                                component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane20" runat="server">
                        <Header>
                            Relative Power</Header>
                        <Content>
                            <div style="text-align: center;">
                                <asp:Image ID="Image39" runat="server" />
                                <asp:Image ID="Image40" runat="server" />
                                <asp:Image ID="Image70" runat="server" />
                               
                            </div>
                              <asp:Label ID="lblInitialFrontRP" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="RPInitialFrontBlockData" runat="server">
                                Due to the differences in athlete’s weights, direct comparison of the Actual Power
                                can be misleading. These graphs show the Relative (percentage of the athlete’s Model)
                                Power that is exerted on the Front block during the Start, which can be used to
                                compare any two athletes.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) relative power created on
                                the back block during the starting action. The position of the pointer indicates
                                the power that the Athlete created, as a percentage of their Model (World Record
                                force level). The color bars along the dial indicate the percentages that are achieved
                                by average (red), good (yellow), and world class (green) starters. The second gauge
                                displays the Vertical (upward) average percentage, while the third gauge indicates
                                the combined Total (Horizontal and Vertical) percentage. The results are outstanding
                                if the average is within the green zone, acceptable if within the yellow zone, and
                                in need of improvement if in the red zone. If the Athlete falls within the green
                                zone, they will typically be in the front at the 10 meter mark of the race. If they
                                are in the yellow zone, they will typically be in the middle of the pack at the
                                beginning of the race. Finally, if they are in the red zone, they will typically
                                be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal percentage while minimizing the
                                Vertical percentage. The Total percentage should be maximized, but only by having
                                a large Horizontal component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                </Panes>
            </ajaxToolkit:Accordion>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="TabPanel4" HeaderText="Current Front Block Data">
        <ContentTemplate>
            <p class="summarytitle">
                Current Front Block Data -
                <asp:Label ID="Label7" runat="server" Text=""></asp:Label></p>
            <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
            <p>
                This Section displays the Block Force results from the Athlete’s Front leg recorded
                during their most recent Start Session. You can use these results to determine their
                current ability to produce a successful Start, as well as compare them to their
                first (Initial) or any subsequent (Other) Session when forces were recorded.
            </p>
            <br />
            <ajaxToolkit:Accordion ID="Accordion4" runat="server" HeaderCssClass="accordionHeader"
                HeaderSelectedCssClass="accordionHeaderSelected">
                <Panes>
                    <ajaxToolkit:AccordionPane ID="AccordionPane13" runat="server">
                        <Header>
                            Actual Forces</Header>
                        <Content>
                            <asp:Image ID="Image21" runat="server" />
                            <asp:Image ID="Image22" runat="server" />
                            <asp:Image ID="Image23" runat="server" />
                            <asp:Label ID="lblCurrentFrontAF" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="AFCurrentFrontBlockData" runat="server">
                                These graphs show the Actual Forces (in kilograms) that are exerted on the Front
                                block during the Start. These results are a good indication as to whether the athlete
                                can produce the level of force required to produce a successful start.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) average force created on the
                                back block during the starting action. The position of the pointer indicates the
                                force that the Athlete created. The color bars along the dial indicate the forces
                                that are achieved by average (red), good (yellow), and world class (green) starters.
                                The second gauge displays the Vertical (upward) average force, while the third gauge
                                indicates the combined Total (Horizontal and Vertical) average force. The results
                                are outstanding if the average is within the green zone, acceptable if within the
                                yellow zone, and in need of improvement if in the red zone. If the Athlete falls
                                within the green zone, they will typically be in the front at the 10 meter mark
                                of the race. If they are in the yellow zone, they will typically be in the middle
                                of the pack at the beginning of the race. Finally, if they are in the red zone,
                                they will typically be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal force while minimizing the Vertical
                                force. The Total force should be maximized, but only by having a large Horizontal
                                component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane14" runat="server">
                        <Header>
                            Relative Forces</Header>
                        <Content>
                            <asp:Image ID="Image24" runat="server" />
                            <asp:Image ID="Image25" runat="server" />
                            <asp:Image ID="Image26" runat="server" />
                            <asp:Label ID="lblCurrrentFrontRF" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="RFCurrentFrontBlockData" runat="server">
                                Due to the differences in athlete’s weights, direct comparison of the Actual Forces
                                can be misleading. These graphs show the Relative (percentage of the athlete’s Model)
                                Forces that are exerted on the Front block during the Start, which can be used to
                                compare any two athletes.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) relative force created on
                                the back block during the starting action. The position of the pointer indicates
                                the force that the Athlete created, as a percentage of their Model (World Record
                                force level). The color bars along the dial indicate the percentages that are achieved
                                by average (red), good (yellow), and world class (green) starters. The second gauge
                                displays the Vertical (upward) average percentage, while the third gauge indicates
                                the combined Total (Horizontal and Vertical) percentage. The results are outstanding
                                if the average is within the green zone, acceptable if within the yellow zone, and
                                in need of improvement if in the red zone. If the Athlete falls within the green
                                zone, they will typically be in the front at the 10 meter mark of the race. If they
                                are in the yellow zone, they will typically be in the middle of the pack at the
                                beginning of the race. Finally, if they are in the red zone, they will typically
                                be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal percentage while minimizing the
                                Vertical percentage. The Total percentage should be maximized, but only by having
                                a large Horizontal component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane15" runat="server">
                        <Header>
                            Actual Power</Header>
                        <Content>
                            <div style="text-align: center;">
                                <asp:Image ID="Image27" runat="server" />
                                <asp:Image ID="Image28" runat="server" />
                                <asp:Image ID="Image67" runat="server" />
                               
                            </div>
                             <asp:Label ID="lblCurrrentFrontAP" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="APCurrentFrontBlockData" runat="server">
                                These graphs show the Actual Power (in kilograms/meters/second) that is generated
                                on the Front block during the Start. These results are a good indication as to whether
                                the athlete is explosive enough to produce a successful start.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) average power created on the
                                back block during the starting action. The position of the pointer indicates the
                                power that the Athlete created. The color bars along the dial indicate the power
                                that is achieved by average (red), good (yellow), and world class (green) starters.
                                The second gauge displays the Vertical (upward) average power, while the third gauge
                                indicates the combined Total (Horizontal and Vertical) average power. The results
                                are outstanding if the average is within the green zone, acceptable if within the
                                yellow zone, and in need of improvement if in the red zone. If the Athlete falls
                                within the green zone, they will typically be in the front at the 10 meter mark
                                of the race. If they are in the yellow zone, they will typically be in the middle
                                of the pack at the beginning of the race. Finally, if they are in the red zone,
                                they will typically be behind during the initial portion of the race
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal power while minimizing the Vertical
                                power. The Total power should be maximized, but only by having a large Horizontal
                                component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane16" runat="server">
                        <Header>
                            Relative Power</Header>
                        <Content>
                            <div style="text-align: center;">
                                <asp:Image ID="Image29" runat="server" />
                                <asp:Image ID="Image30" runat="server" />
                                <asp:Image ID="Image68" runat="server" />
                                
                            </div>
                            <asp:Label ID="lblCurrrentFrontRP" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="RPCurrentFrontBlockData" runat="server">
                                Due to the differences in athlete’s weights, direct comparison of the Actual Power
                                can be misleading. These graphs show the Relative (percentage of the athlete’s Model)
                                Power that is exerted on the Front block during the Start, which can be used to
                                compare any two athletes.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) relative power created on
                                the back block during the starting action. The position of the pointer indicates
                                the power that the Athlete created, as a percentage of their Model (World Record
                                force level). The color bars along the dial indicate the percentages that are achieved
                                by average (red), good (yellow), and world class (green) starters. The second gauge
                                displays the Vertical (upward) average percentage, while the third gauge indicates
                                the combined Total (Horizontal and Vertical) percentage. The results are outstanding
                                if the average is within the green zone, acceptable if within the yellow zone, and
                                in need of improvement if in the red zone. If the Athlete falls within the green
                                zone, they will typically be in the front at the 10 meter mark of the race. If they
                                are in the yellow zone, they will typically be in the middle of the pack at the
                                beginning of the race. Finally, if they are in the red zone, they will typically
                                be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal percentage while minimizing the
                                Vertical percentage. The Total percentage should be maximized, but only by having
                                a large Horizontal component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                </Panes>
            </ajaxToolkit:Accordion>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="TabPanel6" HeaderText="Other Front Block Data">
        <ContentTemplate>
            <div style="float: left; width: 70%; padding: 19px 0px 19px 0px;">
                <p class="summarytitle">
                    Other Front Block Data -
                    <asp:Label ID="Label11" runat="server" Text=""></asp:Label></p>
            </div>
            <div style="float: left; width: 30%; text-align: right; padding: 19px 0px 19px 0px;">
          
                <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_Changed"
                    AutoPostBack="true">
                    <asp:ListItem Value="0">Select Teaching Session</asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <p>
                This Section displays the Block Force results from the Athlete’s Front leg recorded
                during all Sessions that occurred between their Initial and Current Sessions. You
                can use these results to determine their progress from their first (Initial) to
                their most recent (Current) Session when forces were recorded
            </p>
            <ajaxToolkit:Accordion ID="Accordion6" runat="server" HeaderCssClass="accordionHeader"
                HeaderSelectedCssClass="accordionHeaderSelected">
                <Panes>
                    <ajaxToolkit:AccordionPane ID="AccordionPane21" runat="server">
                        <Header>
                            Actual Forces</Header>
                        <Content>
                            <asp:Image ID="Image51" runat="server" />
                            <asp:Image ID="Image52" runat="server" />
                            <asp:Image ID="Image53" runat="server" />
                            <asp:Label ID="lblOtherFrontAF" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="oidp" runat="server">
                                These graphs show the Actual Forces (in kilograms) that are exerted on the Front
                                block during the Start. These results are a good indication as to whether the athlete
                                can produce the level of force required to produce a successful start.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) average force created on the
                                back block during the starting action. The position of the pointer indicates the
                                force that the Athlete created. The color bars along the dial indicate the forces
                                that are achieved by average (red), good (yellow), and world class (green) starters.
                                The second gauge displays the Vertical (upward) average force, while the third gauge
                                indicates the combined Total (Horizontal and Vertical) average force. The results
                                are outstanding if the average is within the green zone, acceptable if within the
                                yellow zone, and in need of improvement if in the red zone. If the Athlete falls
                                within the green zone, they will typically be in the front at the 10 meter mark
                                of the race. If they are in the yellow zone, they will typically be in the middle
                                of the pack at the beginning of the race. Finally, if they are in the red zone,
                                they will typically be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal force while minimizing the Vertical
                                force. The Total force should be maximized, but only by having a large Horizontal
                                component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane22" runat="server">
                        <Header>
                            Relative Forces</Header>
                        <Content>
                            <asp:Image ID="Image54" runat="server" />
                            <asp:Image ID="Image55" runat="server" />
                            <asp:Image ID="Image56" runat="server" />
                            <asp:Label ID="lblOtherFrontRF" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            <p id="oisp" runat="server">
                                Due to the differences in athlete’s weights, direct comparison of the Actual Forces
                                can be misleading. These graphs show the Relative (percentage of the athlete’s Model)
                                Forces that are exerted on the Front block during the Start, which can be used to
                                compare any two athletes.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) relative force created on
                                the back block during the starting action. The position of the pointer indicates
                                the force that the Athlete created, as a percentage of their Model (World Record
                                force level). The color bars along the dial indicate the percentages that are achieved
                                by average (red), good (yellow), and world class (green) starters. The second gauge
                                displays the Vertical (upward) average percentage, while the third gauge indicates
                                the combined Total (Horizontal and Vertical) percentage. The results are outstanding
                                if the average is within the green zone, acceptable if within the yellow zone, and
                                in need of improvement if in the red zone. If the Athlete falls within the green
                                zone, they will typically be in the front at the 10 meter mark of the race. If they
                                are in the yellow zone, they will typically be in the middle of the pack at the
                                beginning of the race. Finally, if they are in the red zone, they will typically
                                be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal percentage while minimizing the
                                Vertical percentage. The Total percentage should be maximized, but only by having
                                a large Horizontal component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane23" runat="server">
                        <Header>
                            Actual Power</Header>
                        <Content>
                            <div style="text-align: left;">
                                <asp:Image ID="Image57" runat="server" />
                                <asp:Image ID="Image58" runat="server" />
                                <asp:Label ID="lblOtherFrontAP" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                                <asp:Image ID="Image71" runat="server" />
                            </div>
                            <p id="oilp" runat="server">
                                These graphs show the Actual Power (in kilograms/meters/second) that is generated
                                on the Front block during the Start. These results are a good indication as to whether
                                the athlete is explosive enough to produce a successful start.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) average power created on the
                                back block during the starting action. The position of the pointer indicates the
                                power that the Athlete created. The color bars along the dial indicate the power
                                that is achieved by average (red), good (yellow), and world class (green) starters.
                                The second gauge displays the Vertical (upward) average power, while the third gauge
                                indicates the combined Total (Horizontal and Vertical) average power. The results
                                are outstanding if the average is within the green zone, acceptable if within the
                                yellow zone, and in need of improvement if in the red zone. If the Athlete falls
                                within the green zone, they will typically be in the front at the 10 meter mark
                                of the race. If they are in the yellow zone, they will typically be in the middle
                                of the pack at the beginning of the race. Finally, if they are in the red zone,
                                they will typically be behind during the initial portion of the race
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal power while minimizing the Vertical
                                power. The Total power should be maximized, but only by having a large Horizontal
                                component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane24" runat="server">
                        <Header>
                            Relative Power</Header>
                        <Content>
                            <div style="text-align: left;">
                                <asp:Image ID="Image59" runat="server" />
                                <asp:Image ID="Image60" runat="server" />
                                <asp:Image ID="Image72" runat="server" />
                                 <asp:Label ID="lblOtherFrontRP" runat="server" Visible="false"><b>No Force Data available for this Section</b></asp:Label>
                            </div>
                            <p id="oisdp" runat="server">
                                Due to the differences in athlete’s weights, direct comparison of the Actual Power
                                can be misleading. These graphs show the Relative (percentage of the athlete’s Model)
                                Power that is exerted on the Front block during the Start, which can be used to
                                compare any two athletes.
                                <br />
                                <br />
                                The first gauge shows the Horizontal (down the track) relative power created on
                                the back block during the starting action. The position of the pointer indicates
                                the power that the Athlete created, as a percentage of their Model (World Record
                                force level). The color bars along the dial indicate the percentages that are achieved
                                by average (red), good (yellow), and world class (green) starters. The second gauge
                                displays the Vertical (upward) average percentage, while the third gauge indicates
                                the combined Total (Horizontal and Vertical) percentage. The results are outstanding
                                if the average is within the green zone, acceptable if within the yellow zone, and
                                in need of improvement if in the red zone. If the Athlete falls within the green
                                zone, they will typically be in the front at the 10 meter mark of the race. If they
                                are in the yellow zone, they will typically be in the middle of the pack at the
                                beginning of the race. Finally, if they are in the red zone, they will typically
                                be behind during the initial portion of the race.
                                <br />
                                <br />
                                Note that the goal is to maximize the Horizontal percentage while minimizing the
                                Vertical percentage. The Total percentage should be maximized, but only by having
                                a large Horizontal component.
                            </p>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                </Panes>
            </ajaxToolkit:Accordion>
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>
