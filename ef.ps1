# clear screen
Clear-Host

# add migration (initial)
dotnet ef migrations add -v -p ${PWD}/src/Hangfire.JobManagement/Hangfire.JobManagement.csproj `
                            -o ${PWD}/src/Hangfire.JobManagement/Data/Migrations/ `
                            initial
