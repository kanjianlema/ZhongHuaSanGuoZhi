﻿namespace PersonDetailPlugin
{
    using GameFreeText;
    using GameGlobal;
    using GameObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using PluginInterface;
    using PluginInterface.BaseInterface;
    using System;
    using System.Drawing;
    using System.Xml;

    public class PersonDetailPlugin : GameObject, IPersonDetail, IBasePlugin, IPluginXML, IPluginGraphics
    {
        private string author = "clip_on";
        private const string DataPath = @"GameComponents\PersonDetail\Data\";
        private string description = "人物细节显示";
        private GraphicsDevice graphicsDevice;
        private const string Path = @"GameComponents\PersonDetail\";
        private PersonDetail personDetail = new PersonDetail();
        private string pluginName = "PersonDetailPlugin";
        private string version = "1.0.0";
        private const string XMLFilename = "PersonDetailData.xml";

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.personDetail.IsShowing)
            {
                this.personDetail.Draw(spriteBatch);
            }
        }

        public void Initialize()
        {
        }

        public void LoadDataFromXMLDocument(string filename)
        {
            XmlNode node3;
            Font font;
            Microsoft.Xna.Framework.Graphics.Color color;
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode nextSibling = document.FirstChild.NextSibling;
            XmlNode node = nextSibling.ChildNodes.Item(0);
            this.personDetail.BackgroundSize.X = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.BackgroundSize.Y = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.BackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonDetail\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(1);
            Microsoft.Xna.Framework.Rectangle rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personDetail.SurNameText = new FreeText(this.graphicsDevice, font, color);
            this.personDetail.SurNameText.Position = rectangle;
            this.personDetail.SurNameText.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(2);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personDetail.GivenNameText = new FreeText(this.graphicsDevice, font, color);
            this.personDetail.GivenNameText.Position = rectangle;
            this.personDetail.GivenNameText.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(3);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personDetail.CalledNameText = new FreeText(this.graphicsDevice, font, color);
            this.personDetail.CalledNameText.Position = rectangle;
            this.personDetail.CalledNameText.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(4);
            this.personDetail.PortraitClient = StaticMethods.LoadRectangleFromXMLNode(node);
            node = nextSibling.ChildNodes.Item(5);
            for (int i = 0; i < node.ChildNodes.Count; i += 2)
            {
                LabelText item = new LabelText();
                node3 = node.ChildNodes.Item(i);
                rectangle = StaticMethods.LoadRectangleFromXMLNode(node3);
                StaticMethods.LoadFontAndColorFromXMLNode(node3, out font, out color);
                item.Label = new FreeText(this.graphicsDevice, font, color);
                item.Label.Position = rectangle;
                item.Label.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node3.Attributes.GetNamedItem("Align").Value);
                item.Label.Text = node3.Attributes.GetNamedItem("Label").Value;
                node3 = node.ChildNodes.Item(i + 1);
                rectangle = StaticMethods.LoadRectangleFromXMLNode(node3);
                StaticMethods.LoadFontAndColorFromXMLNode(node3, out font, out color);
                item.Text = new FreeText(this.graphicsDevice, font, color);
                item.Text.Position = rectangle;
                item.Text.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node3.Attributes.GetNamedItem("Align").Value);
                item.PropertyName = node3.Attributes.GetNamedItem("PropertyName").Value;
                this.personDetail.LabelTexts.Add(item);
            }
            node = nextSibling.ChildNodes.Item(6);
            node3 = node.ChildNodes.Item(0);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node3);
            StaticMethods.LoadFontAndColorFromXMLNode(node3, out font, out color);
            this.personDetail.PersonalTitleLabelText.Label = new FreeText(this.graphicsDevice, font, color);
            this.personDetail.PersonalTitleLabelText.Label.Position = rectangle;
            this.personDetail.PersonalTitleLabelText.Label.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node3.Attributes.GetNamedItem("Align").Value);
            this.personDetail.PersonalTitleLabelText.Label.Text = node3.Attributes.GetNamedItem("Label").Value;
            node3 = node.ChildNodes.Item(1);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node3);
            StaticMethods.LoadFontAndColorFromXMLNode(node3, out font, out color);
            this.personDetail.PersonalTitleLabelText.Text = new FreeText(this.graphicsDevice, font, color);
            this.personDetail.PersonalTitleLabelText.Text.Position = rectangle;
            this.personDetail.PersonalTitleLabelText.Text.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node3.Attributes.GetNamedItem("Align").Value);
            this.personDetail.PersonalTitleLabelText.PropertyName = node3.Attributes.GetNamedItem("PropertyName").Value;
            node3 = node.ChildNodes.Item(2);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node3);
            StaticMethods.LoadFontAndColorFromXMLNode(node3, out font, out color);
            this.personDetail.CombatTitleLabelText.Label = new FreeText(this.graphicsDevice, font, color);
            this.personDetail.CombatTitleLabelText.Label.Position = rectangle;
            this.personDetail.CombatTitleLabelText.Label.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node3.Attributes.GetNamedItem("Align").Value);
            this.personDetail.CombatTitleLabelText.Label.Text = node3.Attributes.GetNamedItem("Label").Value;
            node3 = node.ChildNodes.Item(3);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node3);
            StaticMethods.LoadFontAndColorFromXMLNode(node3, out font, out color);
            this.personDetail.CombatTitleLabelText.Text = new FreeText(this.graphicsDevice, font, color);
            this.personDetail.CombatTitleLabelText.Text.Position = rectangle;
            this.personDetail.CombatTitleLabelText.Text.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node3.Attributes.GetNamedItem("Align").Value);
            this.personDetail.CombatTitleLabelText.PropertyName = node3.Attributes.GetNamedItem("PropertyName").Value;
            node = nextSibling.ChildNodes.Item(7);
            this.personDetail.SkillBlockSize.X = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.SkillBlockSize.Y = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.SkillDisplayOffset.X = int.Parse(node.Attributes.GetNamedItem("OffsetX").Value);
            this.personDetail.SkillDisplayOffset.Y = int.Parse(node.Attributes.GetNamedItem("OffsetY").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personDetail.AllSkillTexts = new FreeTextList(this.graphicsDevice, font, color);
            this.personDetail.AllSkillTexts.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            Microsoft.Xna.Framework.Graphics.Color color2 = new Microsoft.Xna.Framework.Graphics.Color {
                PackedValue = uint.Parse(node.Attributes.GetNamedItem("SkillColor").Value)
            };
            this.personDetail.PersonSkillTexts = new FreeTextList(this.graphicsDevice, font, color2);
            this.personDetail.PersonSkillTexts.Align = this.personDetail.AllSkillTexts.Align;
            Microsoft.Xna.Framework.Graphics.Color color3 = new Microsoft.Xna.Framework.Graphics.Color {
                PackedValue = uint.Parse(node.Attributes.GetNamedItem("LearnableColor").Value)
            };
            this.personDetail.LearnableSkillTexts = new FreeTextList(this.graphicsDevice, font, color3);
            this.personDetail.LearnableSkillTexts.Align = this.personDetail.AllSkillTexts.Align;
            node = nextSibling.ChildNodes.Item(8);
            this.personDetail.StuntClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.StuntText.ClientWidth = this.personDetail.StuntClient.Width;
            this.personDetail.StuntText.ClientHeight = this.personDetail.StuntClient.Height;
            this.personDetail.StuntText.RowMargin = int.Parse(node.Attributes.GetNamedItem("RowMargin").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personDetail.StuntText.Builder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.personDetail.StuntText.DefaultColor = color;
            node = nextSibling.ChildNodes.Item(9);
            this.personDetail.InfluenceClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.InfluenceText.ClientWidth = this.personDetail.InfluenceClient.Width;
            this.personDetail.InfluenceText.ClientHeight = this.personDetail.InfluenceClient.Height;
            this.personDetail.InfluenceText.RowMargin = int.Parse(node.Attributes.GetNamedItem("RowMargin").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personDetail.InfluenceText.Builder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.personDetail.InfluenceText.DefaultColor = color;
            node = nextSibling.ChildNodes.Item(10);
            this.personDetail.ConditionClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.ConditionText.ClientWidth = this.personDetail.ConditionClient.Width;
            this.personDetail.ConditionText.ClientHeight = this.personDetail.ConditionClient.Height;
            this.personDetail.ConditionText.RowMargin = int.Parse(node.Attributes.GetNamedItem("RowMargin").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personDetail.ConditionText.Builder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.personDetail.ConditionText.DefaultColor = color;
            node = nextSibling.ChildNodes.Item(11);
            this.personDetail.BiographyClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.BiographyText.ClientWidth = this.personDetail.BiographyClient.Width;
            this.personDetail.BiographyText.ClientHeight = this.personDetail.BiographyClient.Height;
            this.personDetail.BiographyText.RowMargin = int.Parse(node.Attributes.GetNamedItem("RowMargin").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personDetail.BiographyText.Builder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.personDetail.BiographyText.DefaultColor = color;
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"GameComponents\PersonDetail\PersonDetailData.xml");
        }

        public void SetPerson(object person)
        {
            this.personDetail.SetPerson(person as Person);
        }

        public void SetPosition(ShowPosition showPosition)
        {
            this.personDetail.SetPosition(showPosition);
        }

        public void SetScreen(object screen)
        {
            this.personDetail.Initialize(screen as Screen);
        }

        public void Update(GameTime gameTime)
        {
        }

        public string Author
        {
            get
            {
                return this.author;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
        }

        public object Instance
        {
            get
            {
                return this;
            }
        }

        public bool IsShowing
        {
            get
            {
                return this.personDetail.IsShowing;
            }
            set
            {
                this.personDetail.IsShowing = value;
            }
        }

        public string PluginName
        {
            get
            {
                return this.pluginName;
            }
        }

        public string Version
        {
            get
            {
                return this.version;
            }
        }
    }
}

