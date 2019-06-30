export class Question {

    Id: number;
    // Question show order in this survey
    Order: number;
    // is it reqired to answer this question in this survey
    public IsMandatory: boolean;
    // question text which will show when ask the question
    public Text: string;
    // question text which will show when ask the question
    public Type: string;
    // question current status "active,inactive,pendding,..."
    public Status: string;

    public checked: boolean;

    public intLevel:number;

    public intParentQuestionId:number;
}