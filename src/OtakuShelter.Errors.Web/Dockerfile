FROM microsoft/dotnet:2.2-sdk AS build
COPY . /otakushelter/errors/service
WORKDIR /otakushelter/errors/service/src/OtakuShelter.Errors.Web
RUN dotnet publish -c Release -o artifacts

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /otakushelter/errors/service
COPY --from=build /otakushelter/errors/service/src/OtakuShelter.Errors.Web/artifacts ./
ENTRYPOINT ["dotnet", "OtakuShelter.Errors.Web.dll"] 