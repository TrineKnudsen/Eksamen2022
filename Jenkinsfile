pipeline {
    agent any
    triggers {
        pollSCM("* * * * *")
    }
    stages {
        stage("Build"){
        when {
        anyOf {
        changeset "SOSU2022_BackEnd/SOSU2022_BackEnd.Domain"
        changeset "SOSU2022_BackEnd/SOSU2022_BackEnd.Core"
        changeset "SOSU2022_BackEnd/SOSU2022_BackEnd.DataAccess"
        changeset "SOSU2022_BackEnd/SOSU2022_BackEnd.DataWepApi"
        }
        }
            steps {
                sh "dotnet build SOSU2022_BackEnd/SOSU2022_BackEnd.sln"
            }
        }
    }
}