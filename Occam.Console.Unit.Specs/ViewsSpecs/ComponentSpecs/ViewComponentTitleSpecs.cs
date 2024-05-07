using FakeItEasy;
using Occam.Console.Views.Components;
using Xunit;
namespace Occam.Console.Unit.Specs.ViewsSpecs.ComponentSpecs;

public class ViewComponentTitleSpecs
{
        public class WhenTitleIsSet
        {
            [Theory]
            [InlineData(0,0)]
            [InlineData(1,1)]
            public void Should_show_empty_char_before_title(int xPosition, int yPosition)
            {
                var console = A.Fake<IGameConsole>();
        
                var component = new ViewComponentTitle(console);
        
                component.SetValue("Title");
                component.SetPosition(xPosition,yPosition);
                component.SetMaxLength(8);
                component.Render();
        
                A.CallTo(() => console.WriteAt(1+xPosition, 0+yPosition,' ')).MustHaveHappened(); 
            }
            [Theory]
            [InlineData(0,0)]
            [InlineData(1,1)]
            public void Should_show_title_chars_starting_at_left_2(int xPosition, int yPosition)
            {
                var console = A.Fake<IGameConsole>();
        
                var component = new ViewComponentTitle(console);
        
                component.SetPosition(xPosition,yPosition);
                component.SetValue("Title");
                component.SetMaxLength(8);

                component.Render();
        
                A.CallTo(() => console.WriteAt(2+xPosition, 0+yPosition,'T')).MustHaveHappened(); 
                A.CallTo(() => console.WriteAt(3+xPosition, 0+yPosition,'i')).MustHaveHappened(); 
                A.CallTo(() => console.WriteAt(4+xPosition, 0+yPosition,'t')).MustHaveHappened(); 
                A.CallTo(() => console.WriteAt(5+xPosition, 0+yPosition,'l')).MustHaveHappened(); 
                A.CallTo(() => console.WriteAt(6+xPosition, 0+yPosition,'e')).MustHaveHappened(); 
            }
            [Theory]
            [InlineData(0,0)]
            [InlineData(1,1)]
            public void Should_show_empty_char_after_title(int xPosition, int yPosition)
            {
                var console = A.Fake<IGameConsole>();
        
                var component = new ViewComponentTitle(console);
                
                component.SetPosition(xPosition,yPosition);
                component.SetValue("Title");
                component.SetMaxLength(8);

                component.Render();
        
                A.CallTo(() => console.WriteAt(xPosition+7, yPosition+0,' ')).MustHaveHappened(); 
            }
            
            public class WhenTitleIsGreaterThanMaxLength
            {
                [Theory]
                [InlineData(0,0)]
                [InlineData(1,1)]
                public void Should_show_title_as_much_title_as_possible(int xPosition, int yPosition)
                {
                    var console = A.Fake<IGameConsole>();
                
                    var component = new ViewComponentTitle(console);
                    
                    component.SetPosition(xPosition,yPosition);
                    component.SetValue("Long Title");
                    component.SetMaxLength(8);

                    component.Render();
                
                    A.CallTo(() => console.WriteAt(1+xPosition, 0+yPosition,' ')).MustHaveHappened(); 
                    A.CallTo(() => console.WriteAt(2+xPosition, 0+yPosition,'L')).MustHaveHappened(); 
                    A.CallTo(() => console.WriteAt(3+xPosition, 0+yPosition,'o')).MustHaveHappened(); 
                    A.CallTo(() => console.WriteAt(4+xPosition, 0+yPosition,'n')).MustHaveHappened(); 
                    A.CallTo(() => console.WriteAt(5+xPosition, 0+yPosition,'g')).MustHaveHappened(); 
                    A.CallTo(() => console.WriteAt(6+xPosition, 0+yPosition,' ')).MustHaveHappened(); 
                    
                }
                
                [Theory]
                [InlineData(0,0)]
                [InlineData(1,1)]
                public void Should_not_show_any_title_chars_that_may_obscure_border_corner(int xPosition, int yPosition)
                {
                    var console = A.Fake<IGameConsole>();
                
                    var component = new ViewComponentTitle(console);
                    
                    component.SetPosition(xPosition,yPosition);
                    component.SetValue("Long-Title");
                    component.SetMaxLength(8);
                
                    component.Render();
                
                    A.CallTo(() => console.WriteAt(8+xPosition, 0+yPosition, ' ')).MustNotHaveHappened(); 
                }
                
                [Theory]
                [InlineData(0,0)]
                [InlineData(1,1)]
                public void Should_not_show_orphaned_empty_char_at_end_of_title(int xPosition, int yPosition)
                {
                    var console = A.Fake<IGameConsole>();
                
                    var component = new ViewComponentTitle(console);

                    component.SetPosition(xPosition,yPosition);
                    component.SetValue("Long Title");
                    component.SetMaxLength(8);
                
                    component.Render();
                
                    A.CallTo(() => console.WriteAt(xPosition+8, 0+yPosition, ' ')).MustNotHaveHappened(); 
                }
            }
        }
}