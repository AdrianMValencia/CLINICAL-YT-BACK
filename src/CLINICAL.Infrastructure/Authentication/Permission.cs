namespace CLINICAL.Infrastructure.Authentication
{
    public enum Permission
    {
        ListAnalysis = 1,
        AnalysisById = 2,
        RegisterAnalysis = 3,
        EditAnalysis = 4,
        RemoveAnalysis = 5,
        ChangeStateAnalysis = 6,

        ListExams = 7,
        ExamById = 8,
        RegisterExam = 9,
        EditExam = 10,
        DeleteExam = 11,
        ChangeStateExam = 12,

        ListMedics = 13,
        MedicById = 14,
        RegisterMedic = 15,
        EditMedic = 16,
        DeleteMedic = 17,
        ChangeStateMedic = 18,

        ListPatient = 19,
        PatientById = 20,
        RegisterPatient = 21,
        EditPatient = 22,
        DeletePatient = 23,
        ChangeStatePatient = 24,

        ListResults = 25,
        ResultById = 26,
        RegisterResult = 27,
        EditResult = 28,

        ListTakeExams = 29,
        TakeExamById = 30,
        RegisterTakeExam = 31,
        EditTakeExam = 32,
        ChangeStateTakeExam = 33,

        RegisterUser = 34
    }
}
