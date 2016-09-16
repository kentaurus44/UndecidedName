//
// Script name: IObserver
//
//
// Programmer: Kentaurus
//

public interface IObserver
{
	void OnNotify(ISubject subject, object[] args);
}
