using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameFramework {
    /// <summary>
    /// Mini label type.
    /// </summary>
    internal enum MiniLabelType {
        None = 0,
        Tag = 1,
        Layer = 2,
        TagOrLayer = 3,
        LayerOrTag = 4,
    }
    /// <summary>
    /// Draw type.
    /// </summary>
    internal enum DrawType {
        Active = 0,
        Static = 1,
        Lock = 2,
        Icon = 3,
        ApplyPrefab = 4
    }
    /// <summary>
    /// Entry mode.
    /// </summary>
    internal enum EntryMode {
        ScriptingError = 256,
        ScriptingWarning = 512,
        ScriptingLog = 1024
    }
    /// <summary>
	/// GUIStyles and GUIContents used in hierarchy
    /// </summary>
    internal static class Styles {
        /// <summary>
        /// Gets the static toggle style.
        /// </summary>
        /// <value>The static toggle style.</value>
        public static GUIStyle staticToggleStyle {
            get {
                var style = new GUIStyle("ShurikenLabel");
                style.alignment = TextAnchor.MiddleCenter;
                return style;
            }
        }
        /// <summary>
        /// Gets the apply prefab style.
        /// </summary>
        /// <value>The apply prefab style.</value>
        public static GUIStyle applyPrefabStyle {
            get {
                var style = new GUIStyle("ShurikenLabel");
                style.alignment = TextAnchor.MiddleCenter;
                return style;
            }
        }
        /// <summary>
        /// The lock toggle style.
        /// </summary>
        public static GUIStyle lockToggleStyle = "IN LockButton";
        /// <summary>
        /// The active toggle style.
        /// </summary>
        public static GUIStyle activeToggleStyle = "OL Toggle";
        /// <summary>
        /// The minilabel style.
        /// </summary>
        public static GUIStyle minilabelStyle = "ShurikenDropdown";
        /// <summary>
        /// The horizontal line.
        /// </summary>
        public static GUIStyle horizontalLine = "EyeDropperHorizontalLine";
        /// <summary>
        /// The label normal.
        /// </summary>
        public static GUIStyle labelNormal = "PR Label";
        /// <summary>
        /// The label disabled.
        /// </summary>
        public static GUIStyle labelDisabled = "PR DisabledLabel";
        /// <summary>
        /// The label prefab.
        /// </summary>
        public static GUIStyle labelPrefab = "PR PrefabLabel";
        /// <summary>
        /// The label prefab disabled.
        /// </summary>
        public static GUIStyle labelPrefabDisabled = "PR DisabledPrefabLabel";
        /// <summary>
        /// The label prefab broken.
        /// </summary>
        public static GUIStyle labelPrefabBroken = "PR BrokenPrefabLabel";
        /// <summary>
        /// The label prefab broken disabled.
        /// </summary>
        public static GUIStyle labelPrefabBrokenDisabled = "PR DisabledBrokenPrefabLabel";
        /// <summary>
        /// The tree line base64.
        /// </summary>
        private const string treeLineBase64 =
@"iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAJUlEQVQ4EWNgIAL8BwJcyphwSRAr
PmoAA8NoGIyGASi/DHw6AADYOwQbvk/7+AAAAABJRU5ErkJggg==";
        /// <summary>
        /// The tree end base64.
        /// </summary>
        private const string treeEndBase64 =
@"iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAK0lEQVQ4EWNgIAL8BwJcyphwSRAr
PmoAA8MwCANGYuIbX0IiRv+oGlqHAABHsQgKWP01jwAAAABJRU5ErkJggg==";
        /// <summary>
        /// The tree middle base64.
        /// </summary>
        private const string treeMiddleBase64 =
@"iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAMUlEQVQ4EWNgIAL8BwJcyphwSRAr
PmoAA8PAhwEjMdGFLx0Qo58BnwEDHwajLmBgAADNbwwQNsi4sgAAAABJRU5ErkJggg==";
        /// <summary>
        /// The tree line.
        /// </summary>
        private static Texture2D _treeLine;
        /// <summary>
        /// The tree middle.
        /// </summary>
        private static Texture2D _treeMiddle;
        /// <summary>
        /// The tree end.
        /// </summary>
        private static Texture2D _treeEnd;
        /// <summary>
        /// The info icon.
        /// </summary>
        private static Texture2D _infoIcon;
        /// <summary>
        /// The warning icon.
        /// </summary>
        private static Texture2D _warningIcon;
        /// <summary>
        /// The error icon.
        /// </summary>
        private static Texture2D _errorIcon;
        /// <summary>
        /// Gets the tree line.
        /// </summary>
        /// <value>The tree line.</value>
        public static Texture2D treeLine {
            get {
                if (!_treeLine)
                    _treeLine = Utility.ConvertToTexture(treeLineBase64);
                return _treeLine;
            }
        }
        /// <summary>
        /// Gets the tree middle.
        /// </summary>
        /// <value>The tree middle.</value>
        public static Texture2D treeMiddle {
            get {
                if (!_treeMiddle)
                    _treeMiddle = Utility.ConvertToTexture(treeMiddleBase64);
                return _treeMiddle;
            }
        }
        /// <summary>
        /// Gets the tree end.
        /// </summary>
        /// <value>The tree end.</value>
        public static Texture2D treeEnd {
            get {
                if (!_treeEnd)
                    _treeEnd = Utility.ConvertToTexture(treeEndBase64);
                return _treeEnd;
            }
        }
        /// <summary>
        /// Gets the info icon.
        /// </summary>
        /// <value>The info icon.</value>
        public static Texture2D infoIcon {
            get {
                if (!_infoIcon)
                    _infoIcon = Utility.LoadIcon("console.infoicon.sml");
                if (!_infoIcon)
                    return Texture2D.blackTexture;
                return _infoIcon;
            }
        }
        /// <summary>
        /// Gets the warning icon.
        /// </summary>
        /// <value>The warning icon.</value>
        public static Texture2D warningIcon {
            get {
                if (!_warningIcon)
                    _warningIcon = Utility.LoadIcon("console.warnicon.sml");
                if (!_warningIcon)
                    return Texture2D.blackTexture;
                return _warningIcon;
            }
        }
        /// <summary>
        /// Gets the error icon.
        /// </summary>
        /// <value>The error icon.</value>
        public static Texture2D errorIcon {
            get {
                if (!_errorIcon)
                    _errorIcon = Utility.LoadIcon("console.erroricon.sml");
                if (!_errorIcon)
                    return Texture2D.blackTexture;
                return _errorIcon;
            }
        }
        /// <summary>
        /// The content of the prefab apply.
        /// </summary>
        public static GUIContent prefabApplyContent = new GUIContent("A", "Apply Prefab Changes");
        /// <summary>
        /// The content of the static.
        /// </summary>
        public static GUIContent staticContent = new GUIContent("S", "Static");
        /// <summary>
        /// The empty content of the static.
        /// </summary>
        public static GUIContent emptyStaticContent = new GUIContent(" ", "Static");
        /// <summary>
        /// The content of the lock.
        /// </summary>
        public static GUIContent lockContent = new GUIContent("", "Lock/Unlock");
        /// <summary>
        /// The content of the active.
        /// </summary>
        public static GUIContent activeContent = new GUIContent("", "Enable/Disable");
        /// <summary>
        /// The content of the tag.
        /// </summary>
        public static GUIContent tagContent = new GUIContent("", "Tag");
        /// <summary>
        /// The content of the layer.
        /// </summary>
        public static GUIContent layerContent = new GUIContent("", "Layer");
    }
    /// <summary>
    /// GUI drawer.
    /// </summary>
    internal static class GUIDrawer {
        /// <summary>
        /// The odd.
        /// </summary>
        private static bool odd;
        /// <summary>
        /// The go.
        /// </summary>
        private static GameObject go;
        /// <summary>
        /// The color of the current.
        /// </summary>
        private static Color currentColor;
        /// <summary>
        /// Start this instance.
        /// </summary>
        [InitializeOnLoadMethod]
        private static void Start() {
            Application.logMessageReceived += (message, stack, type) => {
                EditorApplication.RepaintHierarchyWindow();
            };
            EditorApplication.hierarchyWindowItemOnGUI += (instanceID, rect) => {
                try {
                    var evt = Event.current;
                    //You can change or remove this if statement if it's conflicting with other extension
                    if (evt.Equals(Event.KeyboardEvent("^h"))) {
                        Prefs.enabled = !Prefs.enabled;
                        evt.Use();
                    }
                    if (!Prefs.enabled)
                        return;
                    go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
                    if (!go)
                        return;
                    currentColor = go.GetHierarchyColor();
                    Undo.RecordObject(go, "Hierarchy");
                    if (Prefs.lineSorting)
                        ColorSort(rect);
                    if (Prefs.separator)
                        DrawSeparator(rect);
                    if (Prefs.warning)
                        DrawWarnings(rect);
                    if (Prefs.tree)
                        DrawTree(rect);
                    rect.xMin = rect.xMax - rect.height;
                    rect.x += rect.height - Prefs.offset;
                    var list = Prefs.drawOrder;
                    for (int i = 0; i < list.Count; i++)
                        switch (list[i]) {
                            case DrawType.Active:
                                DrawActiveButton(ref rect);
                                break;
                            case DrawType.Static:
                                DrawStaticButton(ref rect);
                                break;
                            case DrawType.Lock:
                                DrawLockButton(ref rect);
                                break;
                            case DrawType.Icon:
                                DrawIcon(ref rect);
                                break;
                            case DrawType.ApplyPrefab:
                                DrawPrefabApply(ref rect);
                                break;
                        }
                    if (Prefs.labelType != MiniLabelType.None) {
                        DrawMiniLabel(ref rect);
                    }
                    if (Prefs.tooltip) {
                        rect.xMax = rect.xMin;
                        rect.xMin = 0f;
                        DrawTooltip(rect);
                    }
                } catch (Exception e) {
                    Debug.LogErrorFormat("Unexpected exception in enhanced hierarchy: {0}", e.ToString());
                }
            };
        }
        /// <summary>
        /// Draws the static button.
        /// </summary>
        /// <param name="rect">Rect.</param>
        private static void DrawStaticButton(ref Rect rect) {
            rect.x -= rect.height;
            GUI.changed = false;
            GUI.Toggle(rect, go.isStatic, go.isStatic ? Styles.staticContent : Styles.emptyStaticContent, Styles.staticToggleStyle);
            if (GUI.changed)
                go.isStatic = !go.isStatic;
        }
        /// <summary>
        /// Draws the lock button.
        /// </summary>
        /// <param name="rect">Rect.</param>
        private static void DrawLockButton(ref Rect rect) {
            rect.x -= rect.height;

            var locked = go.hideFlags == (go.hideFlags | HideFlags.NotEditable);
            GUI.changed = false;
            GUI.Toggle(rect, locked, Styles.lockContent, Styles.lockToggleStyle);
            if (!GUI.changed)
                return;

            go.hideFlags += locked ? -8 : 8;
            InternalEditorUtility.RepaintAllViews();
        }
        /// <summary>
        /// Draws the active button.
        /// </summary>
        /// <param name="rect">Rect.</param>
        private static void DrawActiveButton(ref Rect rect) {
            rect.x -= rect.height;
            GUI.changed = false;
            GUI.Toggle(rect, go.activeSelf, Styles.activeContent, Styles.activeToggleStyle);
            if (GUI.changed)
                go.SetActive(!go.activeSelf);
        }
        /// <summary>
        /// Draws the icon.
        /// </summary>
        /// <param name="rect">Rect.</param>
        private static void DrawIcon(ref Rect rect) {
            var content = EditorGUIUtility.ObjectContent(go, typeof(GameObject));
            if (!content.image)
                return;
            rect.x -= rect.height;
            content.text = string.Empty;
            content.tooltip = "Change Icon";
            if (GUI.Button(rect, content, EditorStyles.label))
                Utility.ShowIconSelector(go, rect, true);
        }
        /// <summary>
        /// Draws the mini label.
        /// </summary>
        /// <param name="rect">Rect.</param>
        private static void DrawMiniLabel(ref Rect rect) {
            rect.x -= rect.height;
            var style = new GUIStyle(Styles.minilabelStyle);
            style.alignment = TextAnchor.MiddleRight;
            style.clipping = TextClipping.Overflow;
            style.normal.textColor =
            style.hover.textColor =
            style.focused.textColor =
            style.active.textColor = currentColor;
            switch (Prefs.labelType) {
                case MiniLabelType.Tag:
                    DrawTag(ref rect, style);
                    return;
                case MiniLabelType.Layer:
                    DrawLayer(ref rect, style);
                    return;
                case MiniLabelType.LayerOrTag:
                    if (go.tag != "Untagged" && LayerMask.LayerToName(go.layer) == "Default")
                        DrawTag(ref rect, style);
                    else
                        DrawLayer(ref rect, style);
                    return;
                case MiniLabelType.TagOrLayer:
                    if (go.tag == "Untagged" && LayerMask.LayerToName(go.layer) != "Default")
                        DrawLayer(ref rect, style);
                    else
                        DrawTag(ref rect, style);
                    return;
            }
        }
        /// <summary>
        /// Draws the prefab apply.
        /// </summary>
        /// <param name="rect">Rect.</param>
        private static void DrawPrefabApply(ref Rect rect) {
            PrefabUtility.RecordPrefabInstancePropertyModifications(go);
            var mods = PrefabUtility.GetPropertyModifications(go);
            if (mods == null || PrefabUtility.GetPrefabType(go) != PrefabType.PrefabInstance)
                return;
            mods = (from mod in mods
                    where !(mod.target as Transform) &&
                    !mod.propertyPath.Contains("m_Name") &&
                    !mod.InvalidPrefabReference(go)
                    select mod).ToArray();
            if (mods.Length == 0)
                return;
            rect.x -= rect.height;
            if (GUI.Button(rect, Styles.prefabApplyContent, Styles.applyPrefabStyle)) {
                var selected = Selection.objects;
                Selection.activeGameObject = go;
                EditorApplication.ExecuteMenuItem("GameObject/Apply Changes To Prefab");
                Selection.objects = selected;
            }
        }
        /// <summary>
        /// Draws the layer.
        /// </summary>
        /// <param name="rect">Rect.</param>
        /// <param name="style">Style.</param>
        private static void DrawLayer(ref Rect rect, GUIStyle style) {
            var str = LayerMask.LayerToName(go.layer);
            if (str != "Default") {
                var size = style.CalcSize(new GUIContent(str)).x;
                rect.xMin = rect.xMax - size;
            }
            if (go.layer == 0)
                style.imagePosition = ImagePosition.ImageOnly;
            GUI.changed = false;
            EditorGUI.LabelField(rect, Styles.layerContent);
            var layer = EditorGUI.LayerField(rect, go.layer, style);
            if (GUI.changed)
                go.layer = layer;
        }
        /// <summary>
        /// Draws the tag.
        /// </summary>
        /// <param name="rect">Rect.</param>
        /// <param name="style">Style.</param>
        private static void DrawTag(ref Rect rect, GUIStyle style) {
            var str = go.tag;
            if (str == "Untagged")
                str = string.Empty;
            var size = style.CalcSize(new GUIContent(str)).x;
            rect.xMin = rect.xMax - size;
            GUI.changed = false;
            EditorGUI.LabelField(rect, Styles.tagContent);
            str = EditorGUI.TagField(rect, str, style);
            if (string.IsNullOrEmpty(str))
                str = "Untagged";
            if (GUI.changed)
                go.tag = str;
        }
        /// <summary>
        /// Draws the separator.
        /// </summary>
        /// <param name="rect">Rect.</param>
        private static void DrawSeparator(Rect rect) {
            rect.yMin = rect.yMax - 1f;
            EditorGUI.LabelField(rect, string.Empty, Styles.horizontalLine);
        }
        /// <summary>
        /// Draws the warnings.
        /// </summary>
        /// <param name="rect">Rect.</param>
        private static void DrawWarnings(Rect rect) {
            var hasInfo = false;
            var hasWarning = false;
            var hasError = false;
            var entries = Utility.GetLogs();
            var contextEntries = (from entry in entries
                                  where entry.intanceID == go.GetInstanceID()
                                  select entry).ToArray();
            for (int i = 0; i < contextEntries.Length; i++) {
                if (contextEntries[i].mode == (contextEntries[i].mode | EntryMode.ScriptingLog))
                    hasInfo = true;
                if (contextEntries[i].mode == (contextEntries[i].mode | EntryMode.ScriptingWarning))
                    hasWarning = true;
                if (contextEntries[i].mode == (contextEntries[i].mode | EntryMode.ScriptingError))
                    hasError = true;
            }
            if (!hasWarning) {
                var components = go.GetComponents<MonoBehaviour>();
                for (int i = 0; i < components.Length; i++)
                    if (!components[i])
                        hasWarning = true;
            }
            var size = EditorStyles.label.CalcSize(new GUIContent(go.name)).x;
            rect.xMin += size;
            rect.xMax = rect.xMin + rect.height;
            rect.height = 16f;
            rect.xMax = rect.xMin + rect.height;
            if (hasInfo) {
                GUI.DrawTexture(rect, Styles.infoIcon);
                rect.x += rect.width;
            }
            if (hasWarning) {
                GUI.DrawTexture(rect, Styles.warningIcon);
                rect.x += rect.width;
            }
            if (hasError) {
                GUI.DrawTexture(rect, Styles.errorIcon);
                rect.x += rect.width;
            }
        }
        /// <summary>
        /// Draws the tooltip.
        /// </summary>
        /// <param name="rect">Rect.</param>
        private static void DrawTooltip(Rect rect) {
            var content = new GUIContent();
            content.tooltip = string.Format("Tag: {0}\nLayer: {1}", go.tag, LayerMask.LayerToName(go.layer));
            EditorGUI.LabelField(rect, content);
        }
        /// <summary>
        /// Draws the tree.
        /// </summary>
        /// <param name="rect">Rect.</param>
        private static void DrawTree(Rect rect) {
            rect.xMin -= 14f;
            rect.xMax = rect.xMin + 14f;
            GUI.color = currentColor;
            if (go.transform.childCount == 0 && go.transform.parent) {
                if (Utility.LastInHierarchy(go.transform))
                    GUI.DrawTexture(rect, Styles.treeEnd);
                else
                    GUI.DrawTexture(rect, Styles.treeMiddle);
            }
            var parent = go.transform.parent;
            for (rect.x -= 14f; rect.xMin > 0f && parent.parent; rect.x -= 14f) {
                GUI.color = parent.parent.GetHierarchyColor();
                if (!parent.LastInHierarchy())
                    GUI.DrawTexture(rect, Styles.treeLine);
                parent = parent.parent;
            }
            GUI.color = Color.white;
        }
        /// <summary>
        /// Colors the sort.
        /// </summary>
        /// <param name="rect">Rect.</param>
        private static void ColorSort(Rect rect) {
            Color color;
            if (EditorGUIUtility.isProSkin)
                color = new Color(0, 0, 0, 0.10f);
            else
                color = new Color(1, 1, 1, 0.20f);
            rect.xMin = 0f;
            if (odd)
                EditorGUI.DrawRect(rect, color);
            odd = !odd;
        }
    }
    /// <summary>
	/// Editor preferences
    /// </summary>
    internal static class Prefs {
        /// <summary>
        /// The enabled preference.
        /// </summary>
        private const string enabledPref = "HierarchyEnabled";
        /// <summary>
        /// The line preference.
        /// </summary>
        private const string linePref = "HierarchySeparator";
        /// <summary>
        /// The tree preference.
        /// </summary>
        private const string treePref = "HierarchyTree";
        /// <summary>
        /// The warning preference.
        /// </summary>
        private const string warningPref = "HierarchyWarning";
        /// <summary>
        /// The label preference.
        /// </summary>
        private const string labelPref = "HierarchyMiniLabel";
        /// <summary>
        /// The tooltip preference.
        /// </summary>
        private const string tooltipPref = "HierarchyTooltip";
        /// <summary>
        /// The offset preference.
        /// </summary>
        private const string offsetPref = "HierarchyOffset";
        /// <summary>
        /// The line sorting preference.
        /// </summary>
        private const string lineSortingPref = "HierarchyLineSorting";
        /// <summary>
        /// The draw order preference.
        /// </summary>
        private const string drawOrderPref = "HierarchyDrawOrder";
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EnhancedHierarchy.Prefs"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public static bool enabled {
            get {
                return EditorPrefs.GetBool(enabledPref, true);
            }
            set {
                EditorPrefs.SetBool(enabledPref, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EnhancedHierarchy.Prefs"/> is separator.
        /// </summary>
        /// <value><c>true</c> if separator; otherwise, <c>false</c>.</value>
        public static bool separator {
            get {
                return EditorPrefs.GetBool(linePref, true);
            }
            set {
                EditorPrefs.SetBool(linePref, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EnhancedHierarchy.Prefs"/> line sorting.
        /// </summary>
        /// <value><c>true</c> if line sorting; otherwise, <c>false</c>.</value>
        public static bool lineSorting {
            get {
                return EditorPrefs.GetBool(lineSortingPref, true);
            }
            set {
                EditorPrefs.SetBool(lineSortingPref, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EnhancedHierarchy.Prefs"/> is tree.
        /// </summary>
        /// <value><c>true</c> if tree; otherwise, <c>false</c>.</value>
        public static bool tree {
            get {
                return EditorPrefs.GetBool(treePref, true);
            }
            set {
                EditorPrefs.SetBool(treePref, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EnhancedHierarchy.Prefs"/> is warning.
        /// </summary>
        /// <value><c>true</c> if warning; otherwise, <c>false</c>.</value>
        public static bool warning {
            get {
                return EditorPrefs.GetBool(warningPref, true);
            }
            set {
                EditorPrefs.SetBool(warningPref, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EnhancedHierarchy.Prefs"/> is tooltip.
        /// </summary>
        /// <value><c>true</c> if tooltip; otherwise, <c>false</c>.</value>
        public static bool tooltip {
            get {
                return EditorPrefs.GetBool(tooltipPref, true);
            }
            set {
                EditorPrefs.SetBool(tooltipPref, value);
            }
        }
        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        /// <value>The offset.</value>
        public static int offset {
            get {
                return EditorPrefs.GetInt(offsetPref);
            }
            set {
                EditorPrefs.SetInt(offsetPref, value);
            }
        }
        /// <summary>
        /// Gets or sets the type of the label.
        /// </summary>
        /// <value>The type of the label.</value>
        public static MiniLabelType labelType {
            get {
                return (MiniLabelType)EditorPrefs.GetInt(labelPref, 3);
            }
            set {
                EditorPrefs.SetInt(labelPref, (int)value);
            }
        }
        /// <summary>
        /// Gets or sets the draw order.
        /// </summary>
        /// <value>The draw order.</value>
        public static List<DrawType> drawOrder {
            get {
                var list = new List<DrawType>();
                if (!EditorPrefs.HasKey(drawOrderPref + "Count")) {
                    list.Add(DrawType.Active);
                    list.Add(DrawType.Static);
                    list.Add(DrawType.Lock);
                    list.Add(DrawType.Icon);
                    list.Add(DrawType.ApplyPrefab);
                    return list;
                }
                var count = EditorPrefs.GetInt(drawOrderPref + "Count");
                for (int i = 0; i < count; i++)
                    list.Add((DrawType)EditorPrefs.GetInt(drawOrderPref + i));
                drawOrder = list;
                return list;
            }
            set {
                EditorPrefs.SetInt(drawOrderPref + "Count", value.Count);
                for (int i = 0; i < value.Count; i++)
                    EditorPrefs.SetInt(drawOrderPref + i, (int)value[i]);
            }
        }
        /// <summary>
        /// The reorder list.
        /// </summary>
        private static ReorderableList rList;
        /// <summary>
        /// The scroll.
        /// </summary>
        private static Vector2 scroll;
        /// <summary>
        /// Raises the preferences GU event.
        /// </summary>
        [PreferenceItem("Hierarchy")]
        private static void OnPreferencesGUI() {
            scroll = EditorGUILayout.BeginScrollView(scroll, false, false);
            EditorGUILayout.Separator();
            enabled = EditorGUILayout.Toggle("Enabled (Ctrl+H)", enabled);
            EditorGUILayout.HelpBox("Hierarchy window must be selected for the shortcut to work", MessageType.None);
            GUI.enabled = enabled;
            offset = EditorGUILayout.IntField("Offset", offset);
            EditorGUILayout.Separator();
            if (rList == null) {
                rList = new ReorderableList(drawOrder, typeof(DrawType), true, false, false, false);
                rList.showDefaultBackground = false;
                rList.onChangedCallback += (newList) => {
                    drawOrder = newList.list as List<DrawType>;
                };
            }
            var list = rList.list as List<DrawType>;
            DrawTypeToggle("Active toggle", DrawType.Active, list);
            DrawTypeToggle("Static toggle", DrawType.Static, list);
            DrawTypeToggle("Lock toggle", DrawType.Lock, list);
            DrawTypeToggle("GameObject icon", DrawType.Icon, list);
            DrawTypeToggle("Apply Prefab Changes Button", DrawType.ApplyPrefab, list);
            drawOrder = list;
            EditorGUILayout.Separator();
            separator = EditorGUILayout.Toggle("Separator", separator);
            tree = EditorGUILayout.Toggle("Hierarchy tree", tree);
            warning = EditorGUILayout.Toggle("Warnings", warning);
            tooltip = EditorGUILayout.Toggle("Tooltip", tooltip);
            lineSorting = EditorGUILayout.Toggle("Color sorting", lineSorting);
            labelType = (MiniLabelType)EditorGUILayout.EnumPopup("Mini label type", labelType);
            if (rList.count > 1) {
                EditorGUILayout.Separator();
                var rect = EditorGUILayout.GetControlRect(GUILayout.Height(0f));
                rect.yMax += EditorGUIUtility.singleLineHeight;
                EditorGUI.LabelField(rect, "Drawing Order", EditorStyles.boldLabel);
                rList.DoLayoutList();
            }
            GUI.enabled = true;
            EditorGUILayout.EndScrollView();
            EditorApplication.RepaintHierarchyWindow();
        }
        /// <summary>
        /// Draws the type toggle.
        /// </summary>
        /// <param name="label">Label.</param>
        /// <param name="drawType">Draw type.</param>
        /// <param name="list">List.</param>
        private static void DrawTypeToggle(string label, DrawType drawType, List<DrawType> list) {
            GUI.changed = false;
            EditorGUILayout.Toggle(label, list.Contains(drawType));
            if (!GUI.changed)
                return;
            if (list.Contains(drawType))
                list.Remove(drawType);
            else
                list.Add(drawType);
        }
    }
    /// <summary>
	/// GUI and hierarchy utilities
    /// </summary>
    internal static class Utility {
        /// <summary>
        /// Shows the icon selector.
        /// </summary>
        /// <param name="targetObj">Target object.</param>
        /// <param name="activatorRect">Activator rect.</param>
        /// <param name="showLabelIcons">If set to <c>true</c> show label icons.</param>
        public static void ShowIconSelector(Object targetObj, Rect activatorRect, bool showLabelIcons) {
            var type = typeof(Editor).Assembly.GetType("UnityEditor.IconSelector");
            var instance = ScriptableObject.CreateInstance(type);
            var parameters = new object[3];

            parameters[0] = targetObj;
            parameters[1] = activatorRect;
            parameters[2] = showLabelIcons;

            type.InvokeMember("Init", BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, instance, parameters);
        }
        /// <summary>
        /// Converts to texture.
        /// </summary>
        /// <returns>The to texture.</returns>
        /// <param name="source">Source.</param>
        public static Texture2D ConvertToTexture(string source) {
            var bytes = Convert.FromBase64String(source);
            var texture = new Texture2D(0, 0);

            texture.LoadImage(bytes);
            texture.alphaIsTransparency = true;
            texture.hideFlags = HideFlags.HideAndDontSave;
            texture.Apply();

            return texture;
        }
        /// <summary>
        /// Loads the icon.
        /// </summary>
        /// <returns>The icon.</returns>
        /// <param name="icon">Icon.</param>
        public static Texture2D LoadIcon(string icon) {
            var type = typeof(EditorGUIUtility);
            var flags = BindingFlags.Static | BindingFlags.NonPublic;
            var method = type.GetMethod("LoadIcon", flags);

            return method.Invoke(null, new object[] { icon }) as Texture2D;
        }
        /// <summary>
        /// Gets the color of the hierarchy.
        /// </summary>
        /// <returns>The hierarchy color.</returns>
        /// <param name="go">Go.</param>
        public static Color GetHierarchyColor(this GameObject go) {
            if (!go)
                return Color.black;

            var prefabType = PrefabUtility.GetPrefabType(PrefabUtility.FindPrefabRoot(go));
            var active = go.activeInHierarchy;
            var style = active ? Styles.labelNormal : Styles.labelDisabled;

            switch (prefabType) {
                case PrefabType.PrefabInstance:
                case PrefabType.ModelPrefabInstance:
                    style = active ? Styles.labelPrefab : Styles.labelPrefabDisabled;
                    break;
                case PrefabType.MissingPrefabInstance:
                    style = active ? Styles.labelPrefabBroken : Styles.labelPrefabBrokenDisabled;
                    break;
            }

            return style.normal.textColor;
        }
        /// <summary>
        /// Gets the color of the hierarchy.
        /// </summary>
        /// <returns>The hierarchy color.</returns>
        /// <param name="t">T.</param>
        public static Color GetHierarchyColor(this Transform t) {
            if (!t)
                return Color.black;

            return t.gameObject.GetHierarchyColor();
        }
        /// <summary>
        /// Lasts the in hierarchy.
        /// </summary>
        /// <returns><c>true</c>, if in hierarchy was lasted, <c>false</c> otherwise.</returns>
        /// <param name="t">T.</param>
        public static bool LastInHierarchy(this Transform t) {
            if (!t)
                return true;

            return t.parent.GetChild(t.parent.childCount - 1) == t;
        }
        /// <summary>
        /// Lasts the in hierarchy.
        /// </summary>
        /// <returns><c>true</c>, if in hierarchy was lasted, <c>false</c> otherwise.</returns>
        /// <param name="go">Go.</param>
        public static bool LastInHierarchy(this GameObject go) {
            if (!go)
                return true;

            return go.transform.LastInHierarchy();
        }
        /// <summary>
        /// Invalids the prefab reference.
        /// </summary>
        /// <returns><c>true</c>, if prefab reference was invalided, <c>false</c> otherwise.</returns>
        /// <param name="mod">Mod.</param>
        /// <param name="go">Go.</param>
        public static bool InvalidPrefabReference(this PropertyModification mod, GameObject go) {

            var parent = PrefabUtility.FindPrefabRoot(go);
            var comps = parent.GetComponentsInChildren<Component>(true).ToList();
            var gos = (from t in comps
                       where t as Transform
                       select t.gameObject).ToList();

            if (mod.objectReference as Component)
                return !comps.Contains(mod.objectReference as Component);
            else if (mod.objectReference as GameObject)
                return !gos.Contains(mod.objectReference as GameObject);

            return false;
        }
        /// <summary>
        /// Gets the logs.
        /// </summary>
        /// <returns>The logs.</returns>
        public static List<LogEntry> GetLogs() {
            try {
                var logEntriesType = typeof(Editor).Assembly.GetType("UnityEditorInternal.LogEntries");
                var logEntryType = typeof(Editor).Assembly.GetType("UnityEditorInternal.LogEntry");
                var flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance;

                var countMethod = logEntriesType.GetMethod("GetCount", flags);
                var getEntryMethod = logEntriesType.GetMethod("GetEntryInternal", flags);
                var startMethod = logEntriesType.GetMethod("StartGettingEntries", flags);
                var endMethod = logEntriesType.GetMethod("EndGettingEntries", flags);
                var logEntryConstructor = logEntryType.GetConstructor(new Type[0]);

                var logEntry = logEntryConstructor.Invoke(null);
                var count = (int)countMethod.Invoke(null, null);

                var conditionField = logEntryType.GetField("condition");
                var errorNumField = logEntryType.GetField("errorNum");
                var fileField = logEntryType.GetField("file");
                var lineField = logEntryType.GetField("line");
                var modeField = logEntryType.GetField("mode");
                var instanceIDField = logEntryType.GetField("instanceID");
                var identifierField = logEntryType.GetField("identifier");
                var entries = new List<LogEntry>();

                startMethod.Invoke(null, null);

                for (int i = 0; i < count; i++) {
                    getEntryMethod.Invoke(null, new object[] { i, logEntry });

                    var entry = new LogEntry();

                    entry.condition = (string)conditionField.GetValue(logEntry);
                    entry.file = (string)fileField.GetValue(logEntry);
                    entry.errorNum = (int)errorNumField.GetValue(logEntry);
                    entry.line = (int)lineField.GetValue(logEntry);
                    entry.identifier = (int)identifierField.GetValue(logEntry);
                    entry.mode = (EntryMode)modeField.GetValue(logEntry);
                    entry.intanceID = (int)instanceIDField.GetValue(logEntry);

                    entries.Add(entry);
                }

                endMethod.Invoke(null, null);

                return entries;
            } catch {
                return new List<LogEntry>();
            }
        }
    }
    /// <summary>
	/// Console Log Entry
    /// </summary>
    internal struct LogEntry {
        /// <summary>
        /// The condition.
        /// </summary>
        public string condition;
        /// <summary>
        /// The file.
        /// </summary>
        public string file;
        /// <summary>
        /// The error number.
        /// </summary>
        public int errorNum;
        /// <summary>
        /// The line.
        /// </summary>
        public int line;
        /// <summary>
        /// The identifier.
        /// </summary>
        public int identifier;
        /// <summary>
        /// The intance identifier.
        /// </summary>
        public int intanceID;
        /// <summary>
        /// The mode.
        /// </summary>
        public EntryMode mode;
    }
}