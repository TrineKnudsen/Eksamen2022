pipeline {
    agent any
    triggers {
        pollSCM("* * * * *")
    }
    stages {
        stage("Build"){
            steps {
                sh "dotnet build SOSU2022_BackEnd/SOSU2022_BackEnd.sln"
            }
        }
    }
}