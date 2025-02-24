using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

//from https://answers.unity.com/questions/1736606/animation-state-of-controller-not-showing-in-inspe.html?page=2 
public class AnimUnhideTool
{
    [MenuItem("Assets/Animator States Unhide Fix")]
    private static void Fix()
    {
        string errorMsg = "";

        if (Selection.objects.Length < 1)
        {
            errorMsg += "Select animator controller(s) before starting the operation!";
        }
        else
        {
            bool controllerFound = false;
            int issuesFixedCounter = 0;

            foreach (Object o in Selection.objects)
            {
                AnimatorController ac = o as AnimatorController;
                if (ac == null)
                    continue;

                controllerFound = true;

                foreach (AnimatorControllerLayer layer in ac.layers)
                {
                    foreach (ChildAnimatorState curState in layer.stateMachine.states)
                    {
                        issuesFixedCounter = FixState(issuesFixedCounter, curState);
                    }

                    issuesFixedCounter = FixStateMachines(issuesFixedCounter, layer.stateMachine, layer.stateMachine.stateMachines);

                }
                EditorUtility.SetDirty(ac);
            }
            if (!controllerFound)
            {
                errorMsg += "Select animator controller(s) before starting the operation!";
            }
            else
            {
                errorMsg += "Fixed " + issuesFixedCounter + " issues!";
            }
        }
        if (errorMsg.Length > 0)
        {
            EditorUtility.DisplayDialog("Finished", errorMsg, "Ok");
        }
    }

    private static int FixStateMachines(int issuesFixedCounter, AnimatorStateMachine parent, ChildAnimatorStateMachine[] stateMachines)
    {
        if (stateMachines != null)
        {
            foreach (ChildAnimatorStateMachine curStateMachine in stateMachines)
            {
                if (curStateMachine.stateMachine.hideFlags != (HideFlags)1)
                {
                    curStateMachine.stateMachine.hideFlags = (HideFlags)1;
                    issuesFixedCounter++;
                }

                issuesFixedCounter = FixStateMachineBehaviours(issuesFixedCounter, curStateMachine.stateMachine.behaviours);

                issuesFixedCounter = FixStateMachines(issuesFixedCounter, curStateMachine.stateMachine, curStateMachine.stateMachine.stateMachines);

                issuesFixedCounter = FixAnimatorTransitions(issuesFixedCounter, parent.GetStateMachineTransitions(curStateMachine.stateMachine));

                issuesFixedCounter = FixAnimatorTransitions(issuesFixedCounter, curStateMachine.stateMachine.entryTransitions);

                foreach (ChildAnimatorState curState in curStateMachine.stateMachine.states)
                {
                    issuesFixedCounter = FixState(issuesFixedCounter, curState);
                }
            }
        }
        return issuesFixedCounter;
    }

    private static int FixState(int issuesFixedCounter, ChildAnimatorState curState)
    {
        if (curState.state.hideFlags != (HideFlags)1)
        {
            curState.state.hideFlags = (HideFlags)1;
            issuesFixedCounter++;
        }

        issuesFixedCounter = FixMotion(issuesFixedCounter, curState.state.motion);

        issuesFixedCounter = FixStateTransitions(issuesFixedCounter, curState.state.transitions);

        issuesFixedCounter = FixStateMachineBehaviours(issuesFixedCounter, curState.state.behaviours);

        return issuesFixedCounter;
    }

    private static int FixAnimatorTransitions(int issuesFixedCounter, AnimatorTransition[] transitions)
    {
        if (transitions != null)
        {
            foreach (AnimatorTransition curTrans in transitions)
            {
                if (curTrans.hideFlags != (HideFlags)1)
                {
                    curTrans.hideFlags = (HideFlags)1;
                    issuesFixedCounter++;
                }
            }
        }
        return issuesFixedCounter;
    }

    private static int FixStateTransitions(int issuesFixedCounter, AnimatorStateTransition[] transitions)
    {
        if (transitions != null)
        {
            foreach (AnimatorStateTransition curTrans in transitions)
            {
                if (curTrans.hideFlags != (HideFlags)1)
                {
                    curTrans.hideFlags = (HideFlags)1;
                    issuesFixedCounter++;
                }
            }
        }
        return issuesFixedCounter;
    }

    private static int FixStateMachineBehaviours(int issuesFixedCounter, StateMachineBehaviour[] behaviours)
    {
        if (behaviours != null)
        {
            foreach (StateMachineBehaviour behaviour in behaviours)
            {
                if (behaviour.hideFlags != (HideFlags)1)
                {
                    behaviour.hideFlags = (HideFlags)1;
                    issuesFixedCounter++;
                }
            }
        }
        return issuesFixedCounter;
    }

    private static int FixMotion(int issuesFixedCounter, Motion motion)
    {
        if (motion != null)
        {
            if (motion.hideFlags != (HideFlags)1)
            {
                motion.hideFlags = (HideFlags)1;
                issuesFixedCounter++;
            }
            BlendTree blendTree = motion as BlendTree;
            if (blendTree != null)
            {
                ChildMotion[] childMotions = blendTree.children;
                if (childMotions != null)
                {
                    foreach (ChildMotion childMotion in childMotions)
                    {
                        issuesFixedCounter = FixMotion(issuesFixedCounter, childMotion.motion);
                    }
                }
            }
        }
        return issuesFixedCounter;
    }
}