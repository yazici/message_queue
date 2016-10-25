﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameFoundations;

public class MessageQueueTest : MonoBehaviour
{
	private Dictionary<MessagePriority, string> priorityLookup = new Dictionary<MessagePriority, string>();

	void Start()
	{
		priorityLookup.Add (MessagePriority.Low, "Low");
		priorityLookup.Add (MessagePriority.Medium, "Medium");
		priorityLookup.Add (MessagePriority.High, "High");
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			MessagePriority priority = MessagePriority.High;

			float random = Random.value;
			if (random < 0.333f) {
				priority = MessagePriority.Low;
			} else if (random < 0.666f) {
				priority = MessagePriority.Medium;
			}

			float showTime = Random.Range (1f, 5f);

			Events.instance.Raise (new MessageEvent (priorityLookup[priority] + " priority message shown at " 
				+ System.DateTime.Now + " for " + showTime + " seconds", Time.time + showTime, priority));
		}
	}
}
