FROM microsoft/dotnet:2.2-sdk AS build
COPY . /otakushelter/error/service
WORKDIR /otakushelter/error/service/src/OtakuShelter.Error.Web
RUN dotnet publish -c Release -o artifacts

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /otakushelter/error/service
COPY --from=build /otakushelter/error/service/src/OtakuShelter.Error.Web/artifacts ./
ENTRYPOINT ["dotnet", "OtakuShelter.Error.Web.dll"] 