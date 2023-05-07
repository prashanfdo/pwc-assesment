
# Demo API
## Demo
[https://prashan-pwc-assement.azurewebsites.net](https://prashan-pwc-assement.azurewebsites.net)
## Notes

- Application uses [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) and DDD patterns  to compose the application and Rest APIs.
- Above demo has been deployed to Azure as an App Service Containerized app.
- Container image has been built with the Dockerfile in the repo.
- Dates are being converted to UTC before saving, to the database to make the app Timezone agnostic.