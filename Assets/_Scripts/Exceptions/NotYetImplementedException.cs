using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotYetImplementedException : System.Exception
{
    public NotYetImplementedException(string message) : base(message) {
        message = "Function has not been implemented yet: " + message;
    }
}
