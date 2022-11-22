using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Door : MonoBehaviour
{
    // Intialization
    string path;
    string WaitForUserString;
    StreamReader reader;
    bool pause;  // whole file finished reading
    bool waiting; // waiting for user input

    // Start is called before the first frame update
    void Start()
    {
        path = "Assets/STEP_code/AnswerTheDoor.step";
        reader = new StreamReader(path);
        WaitForUserString = "wfu";
        pause = false;
        waiting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((!pause) && (!waiting)){
            if (!reader.EndOfStream){
                string current_line = reader.ReadLine();
                if (current_line.Contains(WaitForUserString)){
                    current_line = current_line.Replace("wfu","");
                    Debug.Log(current_line);
                    waiting = true;
                    if (Input.GetKeyDown(KeyCode.Space)){
                        waiting = false;
                    }
                }
                else{
                    Debug.Log(current_line);
                }
            }
            else{
                reader.Close();
                pause = true;
            }
        }
        else if (pause){
            Time.timeScale = 0;
        }
        else{
            if (Input.GetKeyDown(KeyCode.Space)){
                waiting = false;
            }
        }
    }
    
}
