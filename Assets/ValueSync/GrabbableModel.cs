using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class GrabbableModel{

   [RealtimeProperty(1, false, false)]
    private bool _isGrabbed;


    [RealtimeProperty(2, false, false)]
    private int _grabbingClientID;


    [RealtimeProperty(3, false, false)]
    private int _hand;

}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class GrabbableModel : IModel {
    // Properties
    public bool isGrabbed {
        get { return _isGrabbed; }
        set { if (value == _isGrabbed) return; _isGrabbedShouldWrite = true; _isGrabbed = value; }
    }
    public int grabbingClientID {
        get { return _grabbingClientID; }
        set { if (value == _grabbingClientID) return; _grabbingClientIDShouldWrite = true; _grabbingClientID = value; }
    }
    public int hand {
        get { return _hand; }
        set { if (value == _hand) return; _handShouldWrite = true; _hand = value; }
    }
    
    private bool _isGrabbedShouldWrite;
    private bool _grabbingClientIDShouldWrite;
    private bool _handShouldWrite;
    
    public GrabbableModel() {
    }
    
    // Serialization
    enum PropertyID {
        IsGrabbed = 1,
        GrabbingClientID = 2,
        Hand = 3,
    }
    
    public int WriteLength(StreamContext context) {
        int length = 0;
        
        if (context.fullModel) {
            // Write all properties
            length += WriteStream.WriteVarint32Length((uint)PropertyID.IsGrabbed, _isGrabbed ? 1u : 0u);
            length += WriteStream.WriteVarint32Length((uint)PropertyID.GrabbingClientID, (uint)_grabbingClientID);
            length += WriteStream.WriteVarint32Length((uint)PropertyID.Hand, (uint)_hand);
        } else {
            // Unreliable properties
            if (context.unreliableChannel) {
                if (_isGrabbedShouldWrite) {
                    length += WriteStream.WriteVarint32Length((uint)PropertyID.IsGrabbed, _isGrabbed ? 1u : 0u);
                }
                if (_grabbingClientIDShouldWrite) {
                    length += WriteStream.WriteVarint32Length((uint)PropertyID.GrabbingClientID, (uint)_grabbingClientID);
                }
                if (_handShouldWrite) {
                    length += WriteStream.WriteVarint32Length((uint)PropertyID.Hand, (uint)_hand);
                }
            }
        }
        
        return length;
    }
    
    public void Write(WriteStream stream, StreamContext context) {
        if (context.fullModel) {
            // Write all properties
            stream.WriteVarint32((uint)PropertyID.IsGrabbed, _isGrabbed ? 1u : 0u);
            _isGrabbedShouldWrite = false;
            stream.WriteVarint32((uint)PropertyID.GrabbingClientID, (uint)_grabbingClientID);
            _grabbingClientIDShouldWrite = false;
            stream.WriteVarint32((uint)PropertyID.Hand, (uint)_hand);
            _handShouldWrite = false;
        } else {
            // Unreliable properties
            if (context.unreliableChannel) {
                if (_isGrabbedShouldWrite) {
                    stream.WriteVarint32((uint)PropertyID.IsGrabbed, _isGrabbed ? 1u : 0u);
                    _isGrabbedShouldWrite = false;
                }
                if (_grabbingClientIDShouldWrite) {
                    stream.WriteVarint32((uint)PropertyID.GrabbingClientID, (uint)_grabbingClientID);
                    _grabbingClientIDShouldWrite = false;
                }
                if (_handShouldWrite) {
                    stream.WriteVarint32((uint)PropertyID.Hand, (uint)_hand);
                    _handShouldWrite = false;
                }
            }
        }
    }
    
    public void Read(ReadStream stream, StreamContext context) {
        // Loop through each property and deserialize
        uint propertyID;
        while (stream.ReadNextPropertyID(out propertyID)) {
            switch (propertyID) {
                case (uint)PropertyID.IsGrabbed: {
                    _isGrabbed = (stream.ReadVarint32() != 0);
                    _isGrabbedShouldWrite = false;
                    break;
                }
                case (uint)PropertyID.GrabbingClientID: {
                    _grabbingClientID = (int)stream.ReadVarint32();
                    _grabbingClientIDShouldWrite = false;
                    break;
                }
                case (uint)PropertyID.Hand: {
                    _hand = (int)stream.ReadVarint32();
                    _handShouldWrite = false;
                    break;
                }
                default:
                    stream.SkipProperty();
                    break;
            }
        }
    }
}
/* ----- End Normal Autogenerated Code ----- */
