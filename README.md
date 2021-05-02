# DevAnalysis
The project aims to provide insight to project; insights on which you can maybe act. It is not meant to be a source of KPIs,
but as a guide to lead teams better by removing obstacles/seeing problems early. These insights are always to be complemented 
with the knowledge of the team.

The main goal is to use this tools for retrospective - to assess how things went by providing metadata, and then also running
objective metrics on top of that. Then when someone asks you what they can improve, you can give them concrete suggestions that are not
just driven by feeling but also confirmed with metrics. Also, it can be used to access how productivity declines when adding members,
and generally track motivation on project after changes. However, be cautions when analyzing these metrics as we often make up stories
why things went that way (this is human nature) - in a lot of cases, there is no explaination needed (some developers are just better/worse).

# How it Works

The analyser is a batch desktop app, as it is easier to do it as such (maybe later it will be cloud based). It uses the following sources:
* Very detailed git statistics (lines of code + time of commits + project structure), this is run directly on the project
* Details about Jiras linked to developers/QA (we could add other sources)
* Google calendar integration for meetings
* A collection of "metadata" I found useful when analyzing - helping on other projects, PR feedbacks, family problems - this includes personal
data that only managers know. What these allow you is to add personal skews to metrics
* A collection of summed metrics that can be useful to guide developers

This is a very 'personal' tool, and while I try to make it generic, there will be things that I think are important and maybe others don't. I
am very analytical, and a big part of this tool is not so much the "code" but the results/design - what actually matters. It is very possible
that 0 insights can be drawn from this kind of tool - though my hypothesis is that there is value in such tools if used correctly (and not shared
as they could break up teams).




