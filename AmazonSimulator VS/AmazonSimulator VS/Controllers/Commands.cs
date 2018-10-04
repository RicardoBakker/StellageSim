using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Newtonsoft.Json;

namespace Controllers {

    public abstract class Command {

        private string type;
        private Object parameters;

        public Command(string type, Object parameters) {
            this.type = type;
            this.parameters = parameters;
        }

        public string ToJson() {
            return JsonConvert.SerializeObject(new {
                command = type,
                parameters = parameters
            });
        }
    }

    public abstract class Model3DCommand : Command {

<<<<<<< HEAD
        public Model3DCommand(string type, Robot parameters) : base(type, parameters) {
=======
        public Model3DCommand(string type, C3Dmodel parameters) : base(type, parameters) {
>>>>>>> fabian
        }
    }

    public class UpdateModel3DCommand : Model3DCommand {
        
<<<<<<< HEAD
        public UpdateModel3DCommand(Robot parameters) : base("update", parameters) {
=======
        public UpdateModel3DCommand(C3Dmodel parameters) : base("update", parameters) {
>>>>>>> fabian
        }
    }
}