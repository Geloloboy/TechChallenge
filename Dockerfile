FROM fsharp

ADD ResponseCheck.fs src/
RUN cd src && fsharpc ResponseCheck.fs
ENTRYPOINT ["mono", "/root/src/ResponseCheck.exe"]