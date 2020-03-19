using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class FloatModel 
{
   [RealtimeProperty(1,true,true)]
   private float _floatVal;

   [RealtimeProperty(2,true,true)]
   private float _floatVal2;

}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class FloatModel : IModel {
    // Properties
    public float floatVal {
        get { return _cache.LookForValueInCache(_floatVal, entry => entry.floatValSet, entry => entry.floatVal); }
        set { if (value == floatVal) return; _cache.UpdateLocalCache(entry => { entry.floatValSet = true; entry.floatVal = value; return entry; }); FireFloatValDidChange(value); }
    }
    public float floatVal2 {
        get { return _cache.LookForValueInCache(_floatVal2, entry => entry.floatVal2Set, entry => entry.floatVal2); }
        set { if (value == floatVal2) return; _cache.UpdateLocalCache(entry => { entry.floatVal2Set = true; entry.floatVal2 = value; return entry; }); FireFloatVal2DidChange(value); }
    }
    
    // Events
    public delegate void FloatValDidChange(FloatModel model, float value);
    public event         FloatValDidChange floatValDidChange;
    public delegate void FloatVal2DidChange(FloatModel model, float value);
    public event         FloatVal2DidChange floatVal2DidChange;
    
    // Delta updates
    private struct LocalCacheEntry {
        public bool  floatValSet;
        public float floatVal;
        public bool  floatVal2Set;
        public float floatVal2;
    }
    
    private LocalChangeCache<LocalCacheEntry> _cache;
    
    public FloatModel() {
        _cache = new LocalChangeCache<LocalCacheEntry>();
    }
    
    // Events
    public void FireFloatValDidChange(float value) {
        try {
            if (floatValDidChange != null)
                floatValDidChange(this, value);
        } catch (System.Exception exception) {
            Debug.LogException(exception);
        }
    }
    public void FireFloatVal2DidChange(float value) {
        try {
            if (floatVal2DidChange != null)
                floatVal2DidChange(this, value);
        } catch (System.Exception exception) {
            Debug.LogException(exception);
        }
    }
    
    // Serialization
    enum PropertyID {
        FloatVal = 1,
        FloatVal2 = 2,
    }
    
    public int WriteLength(StreamContext context) {
        int length = 0;
        
        if (context.fullModel) {
            // Mark unreliable properties as clean and flatten the in-flight cache.
            // TODO: Move this out of WriteLength() once we have a prepareToWrite method.
            _floatVal = floatVal;
            _floatVal2 = floatVal2;
            _cache.Clear();
            
            // Write all properties
            length += WriteStream.WriteFloatLength((uint)PropertyID.FloatVal);
            length += WriteStream.WriteFloatLength((uint)PropertyID.FloatVal2);
        } else {
            // Reliable properties
            if (context.reliableChannel) {
                LocalCacheEntry entry = _cache.localCache;
                if (entry.floatValSet)
                    length += WriteStream.WriteFloatLength((uint)PropertyID.FloatVal);
                if (entry.floatVal2Set)
                    length += WriteStream.WriteFloatLength((uint)PropertyID.FloatVal2);
            }
        }
        
        return length;
    }
    
    public void Write(WriteStream stream, StreamContext context) {
        if (context.fullModel) {
            // Write all properties
            stream.WriteFloat((uint)PropertyID.FloatVal, _floatVal);
            stream.WriteFloat((uint)PropertyID.FloatVal2, _floatVal2);
        } else {
            // Reliable properties
            if (context.reliableChannel) {
                LocalCacheEntry entry = _cache.localCache;
                if (entry.floatValSet || entry.floatVal2Set)
                    _cache.PushLocalCacheToInflight(context.updateID);
                
                if (entry.floatValSet)
                    stream.WriteFloat((uint)PropertyID.FloatVal, entry.floatVal);
                if (entry.floatVal2Set)
                    stream.WriteFloat((uint)PropertyID.FloatVal2, entry.floatVal2);
            }
        }
    }
    
    public void Read(ReadStream stream, StreamContext context) {
        bool floatValExistsInChangeCache = _cache.ValueExistsInCache(entry => entry.floatValSet);
        bool floatVal2ExistsInChangeCache = _cache.ValueExistsInCache(entry => entry.floatVal2Set);
        
        // Remove from in-flight
        if (context.deltaUpdatesOnly && context.reliableChannel)
            _cache.RemoveUpdateFromInflight(context.updateID);
        
        // Loop through each property and deserialize
        uint propertyID;
        while (stream.ReadNextPropertyID(out propertyID)) {
            switch (propertyID) {
                case (uint)PropertyID.FloatVal: {
                    float previousValue = _floatVal;
                    
                    _floatVal = stream.ReadFloat();
                    
                    if (!floatValExistsInChangeCache && _floatVal != previousValue)
                        FireFloatValDidChange(_floatVal);
                    break;
                }
                case (uint)PropertyID.FloatVal2: {
                    float previousValue = _floatVal2;
                    
                    _floatVal2 = stream.ReadFloat();
                    
                    if (!floatVal2ExistsInChangeCache && _floatVal2 != previousValue)
                        FireFloatVal2DidChange(_floatVal2);
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
